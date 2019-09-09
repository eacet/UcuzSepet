using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UcuzSepet.Application.Admin.Base;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UcuzSepet.Application.Admin.Controllers {
    public class OrderController : BaseController<Order> {
        public new IOrderService Service { get; }

        public OrderController(IOrderService service, ILogger<Order> logger)
            : base(service, logger) {
            Service = service;
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            var result = Service.GetBy(x => x.Id == id);
            return View(result);
        }
    }
}
