using System.Collections.Generic;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;

namespace UcuzSepet.Business.Service.IServices {
    /// <summary>
    /// Product Service for Access Product entities
    /// </summary>
    public interface IProductService : IBaseService<Product> {

        /// <summary>
        /// Get All Products with Related entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetAllProductsWithInclude();

        /// <summary>
        /// Get Product with Related entities by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetByIdWithInclude(int id);
    }
}
