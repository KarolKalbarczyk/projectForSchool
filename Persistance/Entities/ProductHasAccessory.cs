using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Persistance.Entities
{
    public class ProductHasAccessory : IEntity
    {
        public int ProductHasAccessoryId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int AccessoryId { get; set; }
        public Product Accessory { get; set; }

        int IWithId.Id => ProductHasAccessoryId;
    }
}
