using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_pl.Models;
using ASP_pl.Persistance;
using Microsoft.AspNetCore.Authorization;
using ASP_pl.Product;
using ASP_pl.Persistance.Entities;
using ProductE = ASP_pl.Persistance.Entities.Product;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using ASP_pl.Extensions;

namespace ASP_pl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext dbContext;
        UserManager<User> userManager;
        RoleManager<IdentityRole<int>> roleManager;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _logger = logger;
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult SetLang(int id)
        {
            HttpContext.Session.SetLang(id);
            return Redirect(Request.GetTypedHeaders().Referer.ToString());
        }

        public async Task<IActionResult> Pump()
        {
            var admin = new User { UserName = "admin", SecurityStamp = Guid.NewGuid().ToString(), };
            var userRegistration = await userManager.CreateAsync(admin, password: "1_aBcd");
            await roleManager.CreateAsync(new IdentityRole<int> { Name = "Admin" });
            await userManager.AddToRoleAsync(admin, "Admin");
            /*var lang = new Language { Name = "English" };
            var lang2 = new Language { Name = "Polish" };
            dbContext.Languages.AddRange(lang, lang2);
            var translation = new Translation { Language = lang, Text = "description" };
            var translation2 = new Translation { Language = lang, Text = "description2" };
            var translation3 = new Translation { Language = lang2, Text = "opis" };
            dbContext.Translations.AddRange(translation, translation2, translation3);
            var prod = new ProductE { Type = ProductType.Type1, Description = translation, Code = "123" };
            var prod2 = new ProductE { Type = ProductType.Type2, Description = translation2, Code = "456" };
            dbContext.Products.AddRange(prod, prod2);
            var php = new ProductHasPrice { Product = prod, ErpType = Synchronization.ErpType.Erp1, Price = 0.1M };
            var php2 = new ProductHasPrice { Product = prod, ErpType = Synchronization.ErpType.Erp2, Price = 2.1M };
            var php3 = new ProductHasPrice { Product = prod, ErpType = Synchronization.ErpType.Erp2, Price = 81.3M };
            dbContext.ProductHasPrices.AddRange(php, php2, php3);
            dbContext.SaveChanges();*/
            return Redirect("~/");
        }

        public IActionResult Index()
        {
            var u = HttpContext.User;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GoToLogin() => RedirectToAction("Login", "Account");
        public IActionResult GoToRegister() => RedirectToAction("Register", "Account");
        public IActionResult GoToProduct() => RedirectToAction("Index", "Product");
        public IActionResult GoToSynch() => RedirectToAction("Index", "Synchronization");

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
