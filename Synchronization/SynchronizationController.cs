using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Synchronization
{
    [Authorize(Roles = "Admin")]
    public class SynchronizationController : AppController
    {

        private readonly ISynchronizationService _service;

        public SynchronizationController(ISynchronizationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Synchronizations = _service.GetSynchronizations();
            return View("Index", new ErpSynchronizationModel { });
        }

        [HttpPost]
        public async Task<IActionResult> Index(ErpSynchronizationModel model) => await Try(async () =>
        {
            await _service.Synchronize(model.ErpTypes.Where(x => x.Selected).Select(x => x.Erp).ToList());
            return RedirectToAction(nameof(Index), "Synchronization");
        });

        [HttpGet]
        public IActionResult Product(int id)
        {
            ViewBag.ProductId = id;
            return View(nameof(Product), new ProductSynchModel { ProductId = id });
        }

        [HttpPost]
        public async Task<IActionResult> Product(ProductSynchModel model) => await Try(async () =>
        {
            await _service.AddToErp(model.ProductId, model.ErpTypes.Where(x => x.Selected).Select(x => x.Erp).ToList());
            return RedirectToAction(nameof(Index), "Synchronization");
        });


    }
}
