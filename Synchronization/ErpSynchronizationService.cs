using ASP_pl.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ASP_pl.Extensions;
using ASP_pl.Persistance.Entities;
using ProductE = ASP_pl.Persistance.Entities.Product;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text;

namespace ASP_pl.Synchronization
{
    public abstract class ErpSynchronizationService<TModel> : IErpSynchronizationService
        where TModel : IPriceModel
    {
        private IHttpClientFactory _httpFactory;
        private ILogger _logger;
        public abstract ErpType ErpType { get; }
        protected string _endpoint;
        protected AppDbContext _dbContext;
        const int RepeatTimes = 5;

        public ErpSynchronizationService(
            IConfiguration config,
            AppDbContext dbContext,
            ILogger logger,
            IHttpClientFactory httpClientFactory)
        {
            _endpoint = config.GetSection("ErpAddresses").GetSection(ErpType.ToString()).Value;
            _dbContext = dbContext;
            _logger = logger;
            _httpFactory = httpClientFactory;
        }

        protected abstract TModel GetModel(ProductE product);

        private async Task ExecuteHttpRequest(Func<HttpClient, Task> action, Action<SynchronizationModel> onProgress)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);
            var httpClient = _httpFactory.CreateClient();
            ServicePointManager.ServerCertificateValidationCallback =
               delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
               {
                   return true;
               };
            try
            {
                await action(client);
            }
            catch (HttpRequestException)
            {
                onProgress(GetResponse($"Couldn't connect to ERP {ErpType}", status: SynchronizationStatus.Error));
                return;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                onProgress(GetResponse(e.Message, status: SynchronizationStatus.Error));
                throw;
            }
        }
    
        private SynchronizationModel GetResponse(
            string message = "",
            int updated = 0,
            SynchronizationState state = SynchronizationState.Finished,
            SynchronizationStatus status = SynchronizationStatus.Success) =>
            new SynchronizationModel
            {
                Logs = { message },
                ProductsUpdated = updated,
                Status = status,
                State = state,
            };

        public async Task AddToErp(ProductE product, Action<SynchronizationModel> onProgress)
        {
            await ExecuteHttpRequest(async httpClient =>
            {
                var model = GetModel(product);
                var json = JsonConvert.SerializeObject(model);
                var response = await httpClient.Retry(RepeatTimes, () => httpClient.PostAsync(_endpoint, new StringContent(json, Encoding.UTF8, "application/json")));
                onProgress(GetResponse($"Successfully added product to erp {ErpType}"));
            }, onProgress);
        }

        public virtual bool CanHandle(ErpType erpType, ProductE product = null) => erpType == ErpType;

        public async Task SynchronizePrices(Action<SynchronizationModel> onProgress)
        {
            await ExecuteHttpRequest(async httpClient =>
            {
                var answer = await httpClient.Retry(RepeatTimes, () => httpClient.GetAsync(_endpoint));
                var prices = JsonConvert.DeserializeObject<List<TModel>>(await answer.Content.ReadAsStringAsync());
                var codes = prices.Select(x => x.Code);
                var products = _dbContext.Products.Where(p => codes.Contains(p.Code)).ToList();
                var (missingCodes, existingCodes) = prices.SplitOnPredicate(price => products.Any(p => p.Code == price.Code));

                foreach (var code in missingCodes)
                    _logger.LogInformation($"missing product for code {code}");

                var newEntities = UpdatePrices(products, existingCodes, onProgress);
                _dbContext.ProductHasPrices.AddRange(newEntities);
                _dbContext.SaveChanges();
                onProgress(GetResponse(updated: products.Count));
                return;
            }, onProgress);
        }

        private IEnumerable<ProductHasPrice> UpdatePrices(List<ProductE> products, List<TModel> existingCodes, Action<SynchronizationModel> onProgress)
        {
            var updated = 0;
            foreach (var (product, price) in products.OrderBy(p => p.Code).Zip(existingCodes.OrderBy(x => x.Code)))
            {
                var priceE = _dbContext.ProductHasPrices.FirstOrDefault(php => php.ProductId == product.ProductId && php.ErpType == ErpType);
                
                if (priceE == null)
                    yield return new ProductHasPrice { ErpType = ErpType, Price = price.Price, ProductId = product.ProductId };
                else
                    priceE.Price = price.Price;

                updated++;
                onProgress(GetResponse($"product with code {product.Code} successfully updated", updated, SynchronizationState.Ongoing));
            }
        }
    }

}
