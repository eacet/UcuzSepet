using Microsoft.EntityFrameworkCore;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;
using UcuzSepet.Data.EF.IRepositories;

namespace UcuzSepet.Data.EF.Repositories {

    /// <summary>
    /// Category Repository for Category Access
    /// </summary>
    public class CategoryRepository : EFBaseRepository<Category>, ICategoryRepository {
        public CategoryRepository(DbContext context)
            : base(context) { }
    }
}
