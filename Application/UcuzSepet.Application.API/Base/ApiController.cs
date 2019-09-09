using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using UcuzSepet.Data.EF.Components;

namespace UcuzSepet.Application.API.Base {
    /// <summary>
    /// Base Controller for API Controllers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Route("api/[controller]")]
    public class ApiController<T> : Controller where T : class {
        public IBaseService<T> Service { get; }
        public IMapper Mapper { get; }
        public ILogger<T> Logger { get; }

        public ApiController(IBaseService<T> service, IMapper mapper, ILogger<T> logger) {
            Service = service;
            Mapper = mapper;
            Logger = logger;
        }
    }
}
