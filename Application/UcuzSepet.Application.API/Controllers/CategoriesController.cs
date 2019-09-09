using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using UcuzSepet.Application.API.Base;
using UcuzSepet.Application.API.Models;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;


namespace UcuzSepet.Application.API.Controllers {
    public class CategoriesController : ApiController<Category> {

        public new ICategoryService Service { get; }

        public CategoriesController(ICategoryService service, IMapper mapper, ILogger<Category> logger)
            : base(service, mapper, logger) => Service = service;


        [HttpGet]
        public IActionResult Get() {
            try {
                var results = Service.GetAll();
                if (results != null) return Ok(Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(results));
                return NotFound();
            }
            catch (Exception ex) {
                Logger.LogError($"Failed to get brands: {ex}");
            }
            return BadRequest($"Failed to get brands");
        }

    }
}
