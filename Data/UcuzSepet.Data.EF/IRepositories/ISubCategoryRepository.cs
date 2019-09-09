using System.Collections.Generic;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;

namespace UcuzSepet.Data.EF.IRepositories {
    /// <summary>
    /// SubCategory Repository for Access SubCategory Entities
    /// </summary>
    public interface ISubCategoryRepository : IEFBaseRepository<SubCategory> {

        /// <summary>
        /// Get Sub Categories By Category Id
        /// </summary>
        /// <param name="rootCategoryId"></param>
        /// <returns></returns>
        IEnumerable<SubCategory> GetSubCategoriesByRootCategoryId(int rootCategoryId);

        /// <summary>
        ///  Get All Sub Categories with related entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<SubCategory> GetSubCategoriesWithInclude();        
    }
}
