using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using UcuzSepet.Application.Admin.Base;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;


namespace UcuzSepet.Application.Admin.Controllers {
    public class CategoryController : BaseController<Category> {

        public new ICategoryService Service { get; }

        public CategoryController(ICategoryService service, ILogger<Category> logger)
            : base(service, logger) {
            Service = service;
        }

        [HttpGet]
        public override IActionResult Edit(int id) {
            var result = Service.GetBy(x => x.Id == id);
            return View(result);
        }

        //[HttpGet]
        //public new IActionResult Insert() {
        //    ViewBag.CategoryList = Service.GetAll();
        //    return View();
        //}

    }
}
