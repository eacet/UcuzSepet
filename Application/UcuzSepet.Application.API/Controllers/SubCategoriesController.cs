using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using UcuzSepet.Application.API.Base;
using UcuzSepet.Application.API.Models;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Data.Domain.Entities;


namespace UcuzSepet.Application.API.Controllers {
    /// <summary>
    /// Sub Category Controller, Inherited from ApiController<SubCategory>
    /// </summary>
    public class SubCategoriesController : ApiController<SubCategory> {

        public new ISubCategoryService Service { get; }

        public SubCategoriesController(ISubCategoryService service, IMapper mapper, ILogger<SubCategory> logger)
            : base(service, mapper, logger) => Service = service;


        /// <summary>
        /// Return Sub Categories By RootCategoryId
        /// </summary>
        /// <param name="rootCategoryId"></param>
        /// <returns></returns>
        [HttpGet("{rootCategoryId:int}")]
        public IActionResult Get(int rootCategoryId) {
            try {
                var results = Service.FindBy(x => x.RootCategory.Id == rootCategoryId);
                if (results != null) return Ok(Mapper.Map<IEnumerable<SubCategory>, IEnumerable<SubCategoryViewModel>>(results));
                return NotFound();
            }
            catch (Exception ex) {
                Logger.LogError($"Failed to get brands: {ex}");
            }
            return BadRequest($"Failed to get brands");
        }
    }
}
