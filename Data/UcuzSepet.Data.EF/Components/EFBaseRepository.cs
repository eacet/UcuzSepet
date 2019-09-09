using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace UcuzSepet.Data.EF.Components {

    /// <summary>
    /// Base Repository for All Repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EFBaseRepository<T> : IEFBaseRepository<T> where T : class, new() {

        /// <summary>
        /// Base DbContext
        /// </summary>
        protected DbContext DbContext;

        /// <summary>
        /// DbSet for Generic Entity Processes
        /// </summary>
        protected readonly DbSet<T> Dbset;

        public EFBaseRepository(DbContext context) {
            DbContext = context;
            Dbset = DbContext.Set<T>();
        }

        /// <summary>
        /// Get All Entities of T
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll() {
            return Dbset.AsEnumerable();
        }

        /// <summary>
        /// Get All Entities of T by Condition 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate) {
            IEnumerable<T> query = Dbset.Where(predicate).AsEnumerable();
            return query;
        }

        /// <summary>
        /// Get Single Entity by Condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T GetBy(Expression<Func<T, bool>> predicate) {
            return Dbset.FirstOrDefault(predicate);
        }

        /// <summary>
        /// Get Single Entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual T Add(T entity) {
            Dbset.Add(entity);
            return entity;
        }

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Delete(T entity) {
            return SetState(entity, EntityState.Deleted);
        }

        /// <summary>
        /// Edit Entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Edit(T entity) {
            Dbset.Update(entity);
        }

        /// <summary>
        /// Save All Changes on Entities
        /// </summary>
        /// <returns></returns>
        public virtual bool Save() {
            return DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// Change State of Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        protected int SetState(T entity, EntityState state) {
            var entry = DbContext.Entry(entity);
            if (entry.State == EntityState.Detached) {
                Dbset.Attach(entity);
            }
            entry.State = state;
            return DbContext.SaveChanges();
        }
    }
}
