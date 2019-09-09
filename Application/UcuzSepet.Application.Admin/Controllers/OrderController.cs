using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UcuzSepet.Application.Admin.Base;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;


namespace UcuzSepet.Application.Admin.Controllers {
    /// <summary>
    /// Order Controller, Inherited from BaseController<Order>
    /// </summary>
    public class OrderController : BaseController<Order> {
        public new IOrderService Service { get; }

        public OrderController(IOrderService service, ILogger<Order> logger)
            : base(service, logger) {
            Service = service;
        }

        /// <summary>
        /// Edit View, Get Order by Id and Return into Edit View. Override from Base Controller.
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
