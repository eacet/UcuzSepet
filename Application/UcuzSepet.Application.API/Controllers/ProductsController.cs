﻿using AutoMapper;
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

    public class ProductsController : ApiController<Product> {

        public new IProductService Service { get; }

        public ProductsController(IProductService service, IMapper mapper, ILogger<Product> logger)
            : base(service, mapper, logger) => Service = service;


        [HttpGet]
        public IActionResult Get() {
            try {
                var results = Service.GetAll();
                if (results != null) return Ok(Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(results));
                return NotFound();
            }
            catch (Exception ex) {
                Logger.LogError($"Failed to get brands: {ex}");
            }
            return BadRequest($"Failed to get brands");
        }
    }
}
