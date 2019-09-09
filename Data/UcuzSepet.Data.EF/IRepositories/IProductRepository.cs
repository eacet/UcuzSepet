using System;
using System.Collections.Generic;
using System.Text;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;

namespace UcuzSepet.Data.EF.IRepositories {
    /// <summary>
    /// Product Repository for Access Product Entities
    /// </summary>
    public interface IProductRepository : IEFBaseRepository<Product> {

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
        Product GetProductByIdWithInclude(int id);
    }
}
