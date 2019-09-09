using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UcuzSepet.Data.EF.Components;

namespace UcuzSepet.Application.Admin.Base {
    public class BaseController<T> : Controller where T : class {

        public IBaseService<T> Service { get; }
        public ILogger Logger { get; }

        public BaseController(IBaseService<T> service, ILogger logger) {
            Service = service;
            Logger = logger;
        }

        [HttpGet]
        public virtual IActionResult Index() {
            var results = Service.GetAll();
            return View(results);
        }

        [HttpGet]
        public virtual IActionResult Insert() {
            return View();
        }

        [HttpGet]
        public virtual IActionResult Edit(int id) {
            var result = Service.GetById(id);
            return View(result);
        }

        [HttpPost]
        public virtual IActionResult Edit(T model) {
            if (ModelState.IsValid) {
                Service.Edit(model);

                if (Service.Save()) {
                    return RedirectToAction("Index", typeof(T).Name);
                }
            }
            return View();
        }

        [HttpPost]
        public virtual IActionResult Insert(T model) {
            if (ModelState.IsValid) {
                Service.Add(model);
                if (Service.Save()) {
                    return RedirectToAction("Index", typeof(T).Name);
                }
            }
            return View();
        }
    }
}
