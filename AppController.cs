using ASP_pl.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl
{
    public abstract class AppController : Controller
    {
        public IActionResult Try(Func<IActionResult> func, object model = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return func();
                }
                else
                {
                    return View(model);
                }
            }
            catch (ServiceLogicException e)
            {
                return AppJson(false, errors: new List<string> { e.Message });
            }
            catch (Exception)
            {
                return AppJson(false, errors: new List<string> { "Something went wrong" });
            }
        }

        public async Task<IActionResult> Try(Func<Task<IActionResult>> func, object model = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await func();
                }
                else
                {
                    return View(model);
                }
            }
            catch (ServiceLogicException e)
            {
                return AppJson(false, errors: new List<string> { e.Message });
            }
            catch (Exception)
            {
                return AppJson(false, errors: new List<string> { "Something went wrong" });
            }
        }

        protected IActionResult AppJson(bool success, object value = null, IEnumerable<string> errors = null) =>
            new JsonResult(new { Success = success, Errors = errors ?? Enumerable.Empty<string>(), Value = value });
    }
}
