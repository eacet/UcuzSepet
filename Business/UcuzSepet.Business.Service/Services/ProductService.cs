using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;
using UcuzSepet.Data.EF.IRepositories;

namespace UcuzSepet.Business.Service.Services {

    /// <summary>
    /// Product Service for Access Product entities
    /// </summary>
    public class ProductService : BaseService<Product>, IProductService {


        public new IProductRepository Repository { get; }

        /// <summary>
        /// Product Service Constructure
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        public ProductService(IProductRepository repository, ILogger<Product> logger)
            : base(repository, logger) {
            Repository = repository;
        }

        /// <summary>
        /// Get All Products with Related entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAllProductsWithInclude() {
            try {
                return Repository.GetAllProductsWithInclude();
            }
            catch (Exception ex) {
                Logger.LogError($"Failed to get products at GetAllProductsWithInclude() method --> {ex}");
            }
            return null;
        }

        /// <summary>
        /// Get Product with Related entities by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetByIdWithInclude(int id) {
            try {
                return Repository.GetProductByIdWithInclude(id);
            }
            catch (Exception ex) {
                Logger.LogError($"Failed to get products at GetByIdWithInclude(int id) method with parameter: {id} --> {ex}");
            }
            return null;
        }
    }
}
