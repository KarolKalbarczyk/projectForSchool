using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductE = ASP_pl.Persistance.Entities.Product;

namespace ASP_pl.Synchronization
{
    public interface IErpSynchronizationService
    {
        public bool CanHandle(ErpType erpType, ProductE product = null);

        public Task SynchronizePrices(Action<SynchronizationModel> onProgress);

        public Task AddToErp(ProductE product, Action<SynchronizationModel> onProgress);
    }

}
