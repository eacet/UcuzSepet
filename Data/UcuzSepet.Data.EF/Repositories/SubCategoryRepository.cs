using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;
using UcuzSepet.Data.EF.IRepositories;
using System.Linq;

namespace UcuzSepet.Data.EF.Repositories {

    /// <summary>
    /// Sub Category Repository for Access Sub Categories
    /// </summary>
    public class SubCategoryRepository : EFBaseRepository<SubCategory>, ISubCategoryRepository {
        public SubCategoryRepository(DbContext context)
            : base(context) { }

        /// <summary>
        /// Get Sub Categories By Category Id
        /// </summary>
        /// <param name="rootCategoryId"></param>
        /// <returns></returns>
        public IEnumerable<SubCategory> GetSubCategoriesByRootCategoryId(int rootCategoryId) {
            return Dbset.Where(x => x.RootCategory.Id == rootCategoryId).ToList();
        }

        /// <summary>
        ///  Get All Sub Categories with related entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SubCategory> GetSubCategoriesWithInclude() {
            return Dbset.Include(x => x.RootCategory).ToList();
        }
    }
}
