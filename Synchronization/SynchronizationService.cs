using ASP_pl.Exceptions;
using ASP_pl.Extensions;
using ASP_pl.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SynchronizationE = ASP_pl.Persistance.Entities.Synchronization;

namespace ASP_pl.Synchronization
{
    public class SynchronizationService : ISynchronizationService
    {
        private readonly IEnumerable<IErpSynchronizationService> _erpServices;
        private readonly AppDbContext _dbContext;

        public SynchronizationService(IEnumerable<IErpSynchronizationService> erpServices, AppDbContext dbContext)
        {
            _erpServices = erpServices;
            _dbContext = dbContext;
        }

        public async Task Synchronize(List<ErpType> erps)
        {
            foreach (var erp in erps)
            {
                var services = _erpServices.Where(service => service.CanHandle(erp));
                foreach (var service in services)
                {
                    var synchId = InitSynch();
                    await service.SynchronizePrices(model => OnProgress(model, synchId));
                }
            }
        }

        private int InitSynch()
        {
            var synch = new SynchronizationE
            {
                ProductsUpdated = 0,
                Logs = new List<string>(),
                State = SynchronizationState.Awaiting,
                Status = SynchronizationStatus.Success,
            };
            _dbContext.Synchronizations.Add(synch);
            _dbContext.SaveChanges();
            return synch.SynchronizationId;
        }

        private void OnProgress(SynchronizationModel model, int synchId)
        {
            var synch = _dbContext.Synchronizations.Find(synchId);
            synch.Logs.AddRange(model.Logs);
            synch.ProductsUpdated = model.ProductsUpdated;
            synch.State = model.State;
            synch.Status = model.Status;
            _dbContext.SaveChanges();
        }

        public async Task AddToErp(int productId, IEnumerable<ErpType> erps)
        {
            var product = _dbContext.Products.Find(productId) ?? throw new ServiceLogicException("There is no such product");
            foreach (var erp in erps)
            {
                var services = _erpServices.Where(x => x.CanHandle(erp, product));
                foreach (var service in services)
                {
                    var synchId = InitSynch();
                    await service.AddToErp(product, m => OnProgress(m, synchId));
                }
            }
        }

        public IEnumerable<SynchronizationModel> GetSynchronizations() =>
            _dbContext
            .Synchronizations
            .AsEnumerable()
            .Select(x => new SynchronizationModel
            {
                Logs = x.Logs,
                ProductsUpdated = x.ProductsUpdated,
                State = x.State,
                Status = x.Status,
                SynchronizationId = x.SynchronizationId,
            });
    }
}
