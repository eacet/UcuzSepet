using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace UcuzSepet.Data.EF.Components {
    /// <summary>
    /// Base Service for All Services
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> : IBaseService<T> where T : class, new() {
        public IEFBaseRepository<T> Repository { get; set; }
        public ILogger<T> Logger { get; }

        public BaseService(IEFBaseRepository<T> repository, ILogger<T> logger) {
            Repository = repository;
            Logger = logger;
        }

        /// <summary>
        /// Get All Entities of T
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll() {
            var results = Repository.GetAll();
            return results;
        }

        /// <summary>
        /// Get All Entities of T by Condition 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate) {
            var results = Repository.FindBy(predicate);
            return results;

        }

        /// <summary>
        /// Get Single Entity by Condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T GetBy(Expression<Func<T, bool>> predicate) {
            var result = Repository.GetBy(predicate);
            return result;
        }

        /// <summary>
        /// Get Single Entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id) {
            return Repository.GetById(id);
        }

        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Add(T entity) {
            var result = Repository.Add(entity);
            return result;
        }

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity) {
            var result = Repository.Delete(entity);
            return result > 0;
        }

        /// <summary>
        /// Edit Entity
        /// </summary>
        /// <param name="entity"></param>
        public void Edit(T entity) {
            Repository.Edit(entity);
        }

        /// <summary>
        /// Save All Changes on Entities
        /// </summary>
        /// <returns></returns>
        public bool Save() {
            return Repository.Save();
        }

        
    }
}
