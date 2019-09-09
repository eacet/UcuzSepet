using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;
using UcuzSepet.Data.EF.IRepositories;

namespace UcuzSepet.Business.Service.Services {

    /// <summary>
    /// SubCategory Service for Access SubCategory entities
    /// </summary>
    public class SubCategoryService : BaseService<SubCategory>, ISubCategoryService {

        public new ISubCategoryRepository Repository { get; }


        /// <summary>
        /// Sub Category Service Constructure
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        public SubCategoryService(ISubCategoryRepository repository, ILogger<SubCategory> logger)
            : base(repository, logger) {
            Repository = repository;
        }

        /// <summary>
        /// Get Sub Categories By Category Id
        /// </summary>
        /// <param name="rootCategoryId"></param>
        /// <returns></returns>
        public IEnumerable<SubCategory> GetSubCategoriesByRootCategoryId(int rootCategoryId) {
            try {
                return Repository.GetSubCategoriesByRootCategoryId(rootCategoryId);
            }
            catch (Exception ex) {
                Logger.LogError($"Failed to get sub categories at GetSubCategoriesByRootCategoryId(int rootCategoryId) method with parameter: {rootCategoryId} --> {ex}");
            }
            return null;
        }

        /// <summary>
        ///  Get All Sub Categories with related entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SubCategory> GetSubCategoriesWithInclude() {
            try {
                return Repository.GetSubCategoriesWithInclude();
            }
            catch (Exception ex) {
                Logger.LogError($"Failed to get sub categories at GetSubCategoriesWithInclude() method --> {ex}");
            }
            return null;
        }
    }
}
