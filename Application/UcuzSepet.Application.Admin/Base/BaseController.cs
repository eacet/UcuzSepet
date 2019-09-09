using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UcuzSepet.Data.EF.Components;

namespace UcuzSepet.Application.Admin.Base {

    /// <summary>
    /// Generic Base Controller. All Controllers will inherit from this Controller
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseController<T> : Controller where T : class {

        public IBaseService<T> Service { get; }
        public ILogger Logger { get; }

        public BaseController(IBaseService<T> service, ILogger logger) {
            Service = service;
            Logger = logger;
        }


        /// <summary>
        /// Generic Index View, Get Entites and Return into Index View
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Index() {
            var results = Service.GetAll();
            return View(results);
        }

        /// <summary>
        /// Generic Insert View
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Insert() {
            return View();
        }

        /// <summary>
        /// Generic Edit View, Get Entity by Id and Return into Edit View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Edit(int id) {
            var result = Service.GetById(id);
            return View(result);
        }


        /// <summary>
        /// Generic Edit Post View, Update Entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Generic Insert Post View, Insert New Entity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
