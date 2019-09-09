using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UcuzSepet.Application.Admin.Base;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Data.Domain.Entities;

namespace UcuzSepet.Application.Admin.Controllers {
    public class BrandController : BaseController<Brand> {

        public new IBrandService Service { get; }

        public BrandController(IBrandService service, ILogger<Brand> logger)
            : base(service, logger) {
            Service = service;
        }


        [HttpGet]
        public override IActionResult Edit(int id) {
            var result = Service.GetBy(x => x.Id == id);
            return View(result);
        }
    }
}
