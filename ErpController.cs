using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl
{
    public class PriceModel
    {
        public decimal? Price { get; set; }
        public string Code { get; set; }
    }
    public class ErpController : AppController
    {
        private static readonly List<PriceModel> priceModels = new List<PriceModel> { new PriceModel { Code = "123", Price = 0.71M }, new PriceModel { Code = "456", Price = 3.354M } };

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Erp()
        {
            return Json(priceModels);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Erp([FromBody] PriceModel model)
        {
            model.Price = (decimal)new Random().NextDouble() * 10;
            priceModels.Add(model);
            return Ok();
        }
    }
}
