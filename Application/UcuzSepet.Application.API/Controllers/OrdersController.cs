using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using UcuzSepet.Application.API.Base;
using UcuzSepet.Application.API.Models;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;

namespace UcuzSepet.Application.API.Controllers {
    /// <summary>
    /// Orders Controller, Inherited from ApiController<Order>
    /// </summary>
    public class OrdersController : ApiController<Order> {

        public new IOrderService Service { get; }

        public OrdersController(IOrderService service, IMapper mapper, ILogger<Order> logger)
            : base(service, mapper, logger) => Service = service;


        /// <summary>
        /// Get Order from body and Create Order
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] OrderViewModel model) {
            try {
                if (ModelState.IsValid) {
                    Service.Add(Mapper.Map<OrderViewModel, Order>(model));

                    if (Service.Save()) {
                        return Ok(model);
                    }
                }
                else
                    return BadRequest(ModelState);
            }
            catch (Exception ex) {
                Logger.LogError($"Failed to save a new order: {ex}");
            }
            return BadRequest($"Failed to save a new order");
        }
    }
}
