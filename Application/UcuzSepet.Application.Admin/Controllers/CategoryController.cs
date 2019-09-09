using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UcuzSepet.Application.Admin.Base;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Data.Domain.Entities;


namespace UcuzSepet.Application.Admin.Controllers {
    /// <summary>
    /// Category Controller, Inherited from BaseController<Category>
    /// </summary>
    public class CategoryController : BaseController<Category> {

        public new ICategoryService Service { get; }

        public CategoryController(ICategoryService service, ILogger<Category> logger)
            : base(service, logger) {
            Service = service;
        }

        /// <summary>
        /// Edit View, Get Category by Id and Return into Edit View. Override from Base Controller.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public override IActionResult Edit(int id) {
            var result = Service.GetBy(x => x.Id == id);
            return View(result);
        }

    }
}
