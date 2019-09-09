using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using UcuzSepet.Application.Admin.Base;
using UcuzSepet.Application.Admin.Models;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Business.Service.Services;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;


namespace UcuzSepet.Application.Admin.Controllers {
    public class ProductController : BaseController<Product> {
        public new IProductService Service { get; }
        public ICategoryService CategoryService { get; }
        public ISubCategoryService SubCategoryService { get; }
        public IBrandService BrandService { get; }

        public ProductController(IProductService service, ILogger<Product> logger, ICategoryService categoryService, ISubCategoryService subCategoryService, IBrandService brandService)
         : base(service, logger) {
            Service = service;
            CategoryService = categoryService;
            SubCategoryService = subCategoryService;
            BrandService = brandService;
        }


        [HttpGet]
        public override IActionResult Index() {
            var results = Service.GetAllProductsWithInclude();
            return View(results);
        }

        [HttpGet]
        public override IActionResult Edit(int id) {

            try {

                var model = Service.GetByIdWithInclude(id);
                var categories = CategoryService.GetAll().ToList();
                ViewBag.Categories = categories;

                var subCategories = SubCategoryService.GetSubCategoriesByRootCategoryId(model.SubCategory.RootCategoryId);
                ViewBag.SubCategories = subCategories;

                var brands = BrandService.GetAll().ToList();
                ViewBag.Brands = brands;

                return View(model);
            }
            catch (Exception ex) {
                Logger.LogError($"Error occured at ProductController at [HttpGet] Edit(int id) method with parameter: {id} --> {ex}");
            }
            return View();
        }

        [HttpGet]
        public override IActionResult Insert() {

            try {
                var categories = CategoryService.GetAll().ToList();
                ViewBag.Categories = categories;

                var brands = BrandService.GetAll().ToList();
                ViewBag.Brands = brands;

                return View();
            }
            catch (Exception ex) {
                Logger.LogError($"Error occured at ProductController at [HttpGet] Insert() method --> {ex}");
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetSubCategories(int categoryId) {
            var subCategories = SubCategoryService.GetSubCategoriesByRootCategoryId(categoryId);
            return Json(new SelectList(subCategories, "Id", "Name"));
        }

        [HttpPost]
        public override IActionResult Edit(Product model) {
            //if (ModelState.IsValid) {
            //    Service.Edit(model);

            //    if (Service.Save()) {
            //        return RedirectToAction("Index");
            //    }
            //}
            //else {
            //    var categories = CategoryService.GetAll().ToList();
            //    ViewBag.Categories = categories;

            //    var subCategories = SubCategoryService.GetSubCategoriesByRootCategoryId(model.SubCategory.RootCategoryId);
            //    ViewBag.SubCategories = subCategories;

            //    var brands = BrandService.GetAll().ToList();
            //    ViewBag.Brands = brands;
            //}
            //return View(model);
            throw new NotImplementedException();
        }
    }
}
