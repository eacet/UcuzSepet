using System.Collections.Generic;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;

namespace UcuzSepet.Business.Service.IServices {
    /// <summary>
    /// SubCategory Service for Access SubCategory entities
    /// </summary>
    public interface ISubCategoryService : IBaseService<SubCategory> {

        /// <summary>
        /// Get Sub Categories By Category Id
        /// </summary>
        /// <param name="rootCategoryId"></param>
        /// <returns></returns>
        IEnumerable<SubCategory> GetSubCategoriesWithInclude();

        /// <summary>
        ///  Get All Sub Categories with related entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<SubCategory> GetSubCategoriesByRootCategoryId(int rootCategoryId);
    }
}
