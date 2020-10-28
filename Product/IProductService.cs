using System.Collections.Generic;

namespace ASP_pl.Product
{
    public interface IProductService
    {
        void AddOrModify(ProductViewModel model);
        IEnumerable<ProductViewModel> GetProducts(int languageId);
        void Invalidate();
    }
}