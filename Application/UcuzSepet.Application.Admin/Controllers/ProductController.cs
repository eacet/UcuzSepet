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
    /// <summary>
    /// Product Controller, Inherited from BaseController<Product>
    /// </summary>
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

        /// <summary>
        /// Index View, Get All Products with related entities and Return into Index View. Override from Base Controller.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public override IActionResult Index() {
            var results = Service.GetAllProductsWithInclude();
            return View(results);
        }

        /// <summary>
        /// Edit View, Get Product by Id with related entities and Return into Edit View. Override from Base Controller.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Insert View, Get related entities and Return into Insert View. Override from Base Controller.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get Sub Categories By Root Category Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetSubCategories(int categoryId) {
            var subCategories = SubCategoryService.GetSubCategoriesByRootCategoryId(categoryId);
            return Json(new SelectList(subCategories, "Id", "Name"));
        }

        /// <summary>
        /// Edit View [HttpPost], Update Product. Override from Base Controller.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public override IActionResult Edit(Product model) {
            throw new NotImplementedException();
        }
    }
}
