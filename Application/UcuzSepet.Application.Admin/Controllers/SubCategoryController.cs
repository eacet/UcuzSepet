using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using UcuzSepet.Application.Admin.Base;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;

namespace UcuzSepet.Application.Admin.Controllers {

    /// <summary>
    /// Sub Category Controller, Inherited from BaseController<SubCategory>
    /// </summary>
    public class SubCategoryController : BaseController<SubCategory> {

        public new ISubCategoryService Service { get; }
        public ICategoryService CategoryService { get; }

        public SubCategoryController(ISubCategoryService service, ILogger<SubCategory> logger, ICategoryService categoryService)
            : base(service, logger) {
            Service = service;
            CategoryService = categoryService;
        }


        /// <summary>
        /// Inser View. Override from Base Controller.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public override IActionResult Insert() {
            FillCategoriesIntoViewBag();
            return View();
        }

        /// <summary>
        /// Edit View, Get Sub Category and Return into the View. Override from Base Controller.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public override IActionResult Edit(int id) {
            FillCategoriesIntoViewBag();
            var result = Service.GetBy(x => x.Id == id);
            return View(result);
        }

        /// <summary>
        /// Index View. Override from Base Controller.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public override IActionResult Index() {
            var results = Service.GetSubCategoriesWithInclude();
            return View(results);
        }

        /// <summary>
        /// Insert View [HttpPost], Create new SubCategory. Override from Base Controller.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public override IActionResult Insert(SubCategory model) {
            if (ModelState.IsValid) {
                Service.Add(model);
                if (Service.Save()) {
                    return RedirectToAction("Index");
                }
            }
            else {
                FillCategoriesIntoViewBag();
            }
            return View();
        }

        /// <summary>
        /// Get All Categories from CategoryService and fill into ViewBag
        /// </summary>
        void FillCategoriesIntoViewBag() {
            var categories = CategoryService.GetAll();
            ViewBag.Categories = categories;
        }

    }
}
