using ASP_pl.Account;
using ASP_pl.Exceptions;
using ASP_pl.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Product
{
    [Authorize]
    public class ProductController: AppController
    {

        private readonly IProductService _productService;
        private readonly IAccountService _accountService;

        public ProductController(IProductService productService, IAccountService accountService)
        {
            _accountService = accountService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var langId = HttpContext.Session.GetLang();
            ViewBag.Products = _productService.GetProducts(langId);
            ViewBag.IsAdmin = _accountService.GetUserRoles(HttpContext.User.Identity.Name).HasFlag(UserRoles.Admin);
            return View();
        }

        [HttpGet]
        public IActionResult Modify(int id) => Try(() =>
        {
            var product = _productService
            .GetProducts(1)
            .FirstOrDefault(x => x.Id == id) 
            ?? throw new ServiceLogicException("No such product");

            return View(nameof(New), new ProductViewModel { Id = id, Code = product.Code, Description = product.Description, });
        });

        [HttpGet]
        public IActionResult New() => View();

        [HttpPost]
        public IActionResult New(ProductViewModel model) => Try(() => 
        {
            _productService.AddOrModify(model);
            return RedirectToAction("Index", "Product");
        }, model);

        public IActionResult Invalidate()
        {
            _productService.Invalidate();
            return RedirectToAction("Index", "Product");
        }
    }
}
