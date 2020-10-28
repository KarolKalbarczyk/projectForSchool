using ASP_pl.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASP_pl.Synchronization
{
    public class Erp1SynchronizationService : ErpSynchronizationService<PriceModel>
    {
        public Erp1SynchronizationService(IConfiguration config, AppDbContext dbContext, ILogger<Erp1SynchronizationService> logger, IHttpClientFactory httpClientFactory) 
            : base(config, dbContext, logger, httpClientFactory)
        {
        }

        public override ErpType ErpType => ErpType.Erp1;

        protected override PriceModel GetModel(Persistance.Entities.Product product) => new PriceModel
        {
            Code = product.Code,
            Price = _dbContext.ProductHasPrices.FirstOrDefault(x => x.ErpType == ErpType && x.ProductId == product.ProductId)?.Price, 
        };
    }
}
