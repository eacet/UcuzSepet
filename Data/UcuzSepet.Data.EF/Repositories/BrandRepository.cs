using Microsoft.EntityFrameworkCore;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;
using UcuzSepet.Data.EF.IRepositories;

namespace UcuzSepet.Data.EF.Repositories {

    /// <summary>
    /// Brand Repository for Brand Access
    /// </summary>
    public class BrandRepository : EFBaseRepository<Brand>, IBrandRepository {
        public BrandRepository(DbContext context)
    : base(context) { }

    }
}
