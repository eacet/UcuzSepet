using Microsoft.Extensions.Logging;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;
using UcuzSepet.Data.EF.IRepositories;

namespace UcuzSepet.Business.Service.Services {

    /// <summary>
    /// Category Service for Access Category entities
    /// </summary>
    public class CategoryService : BaseService<Category>, ICategoryService {
        public CategoryService(ICategoryRepository repository, ILogger<Category> logger)
            : base(repository, logger) { }

    }
}
