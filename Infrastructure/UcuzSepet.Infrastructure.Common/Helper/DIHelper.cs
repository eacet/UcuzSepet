using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Data.EF.IRepositories;

namespace UcuzSepet.Infrastructure.Common.Helper {

    /// <summary>
    /// Dependency Injection Helper
    /// </summary>
    public static class DIHelper {

        /// <summary>
        /// Extension method for Register All Services and Repositories into the .Net Core Injection. 
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServiceAndRepositoryTypes(this IServiceCollection services) {
            var assemblies = new List<Assembly>
            {
                Assembly.GetAssembly(typeof (ICategoryService)), // Service
                Assembly.GetAssembly(typeof (ICategoryRepository)), // Repository
            };

            foreach (var assembly in assemblies) {
                foreach (var type in assembly.GetTypes()) {
                    if ((type.Name.EndsWith("Service") || type.Name.EndsWith("Repository")) && !type.IsInterface) {
                        services.AddScoped(type.GetInterface($"I{type.Name}"), type);
                    }
                }
            }
        }
    }
}
