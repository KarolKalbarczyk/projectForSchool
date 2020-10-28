using ASP_pl.Localization;
using ASP_pl.Persistance.Entities;
using ASP_pl.Synchronization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Product
{
    public class ProductModel : IEntityModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public TranslationModel Description { get; set; }
        public List<(ErpType Erp, decimal? Price)> Prices { get; set; }
        public List<ProductHasAccessoryModel> ProductHasAccessoryModels { get; set; } = new List<ProductHasAccessoryModel>();
    }

    public class ProductViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
        public List<(ErpType Erp, decimal? Price)> Prices { get; set; }
        public List<ProductHasAccessoryModel> ProductHasAccessoryModels { get; set; } = new List<ProductHasAccessoryModel>();
    }
}
