using ASP_pl.Exceptions;
using ASP_pl.Localization;
using ASP_pl.Persistance;
using ASP_pl.Persistance.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductE = ASP_pl.Persistance.Entities.Product;

namespace ASP_pl.Product
{
    public class ProductService : IProductService
    {
        private AppDbContext _dbContext;
        private ILogger _logger;
        private ITypedCache<ProductE, ProductModel> _cache;

        public ProductService(AppDbContext dbContext, ITypedCache<ProductE, ProductModel> cache)
        {
            _dbContext = dbContext;
            _logger = null;
            _cache = cache;
        }

        public void AddOrModify(ProductViewModel model)
        {
            var product = model.Id.HasValue
                ? _dbContext.Products.Find(model.Id.Value)
                : new ProductE();
            product.Code = model.Code;
            product.Description = new Translation { LanguageId = 1, Text = model.Description };
            if (!model.Id.HasValue)
                _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public IEnumerable<ProductViewModel> GetProducts(int languageId) =>
            _cache.GetAll().Select(x => new ProductViewModel
            {
                Code = x.Code,
                Description = x.Description.TranslateTo(languageId, _dbContext),
                Id = x.Id,
                Prices = x.Prices,
                ProductHasAccessoryModels = x.ProductHasAccessoryModels,
            });

        public void Invalidate()
        {
            _cache.Invalidate();
        }
    }
}
