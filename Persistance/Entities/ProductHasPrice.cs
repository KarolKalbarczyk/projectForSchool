using ASP_pl.Synchronization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Persistance.Entities
{
    public class ProductHasPrice : IEntity
    {
        public int ProductHasPriceId { get; set; }
        public decimal? Price { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public ErpType ErpType {get;set;}
        int IWithId.Id => ProductHasPriceId;
    }
}
