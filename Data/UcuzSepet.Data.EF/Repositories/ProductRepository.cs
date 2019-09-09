using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;
using UcuzSepet.Data.EF.IRepositories;

namespace UcuzSepet.Data.EF.Repositories {

    /// <summary>
    /// Order Repository for Order Access
    /// </summary>
    public class ProductRepository : EFBaseRepository<Product>, IProductRepository {
        public ProductRepository(DbContext context)
            : base(context) {
        }

        /// <summary>
        /// Get All Products with Related entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAllProductsWithInclude() {
            return Dbset
                    .Include(x => x.Brand)
                    .Include(x => x.SubCategory)
                    .ThenInclude(x => x.RootCategory)
                    .ToList();
        }

        /// <summary>
        /// Get Product with Related entities by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductByIdWithInclude(int id) {
            return Dbset
                   .Include(x => x.Brand)
                   .Include(x => x.SubCategory)
                   .ThenInclude(x => x.RootCategory)
                   .FirstOrDefault(x => x.Id == id);
        }
    }
}
