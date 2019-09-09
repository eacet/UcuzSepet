using Microsoft.Extensions.Logging;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;

namespace UcuzSepet.Business.Service.Services {
    /// <summary>
    /// Brand Service for Access Brand entities
    /// </summary>
    public class BrandService : BaseService<Brand>, IBrandService {
        public BrandService(IEFBaseRepository<Brand> repository, ILogger<Brand> logger)
            : base(repository, logger) { }
    }
}
