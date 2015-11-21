using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartApi.Persistence.Abstracts;
using SmartApi.Persistence.Facade;
using SmartApi.Shared.Dtos;

namespace SmartApi.Persistence.Repositories
{
    public class SmartApiRepository<TEntity> : ISmartApiRepository<TEntity> where TEntity : DtoBase
    {
        private readonly SmartApiFacade _smartApiFacade;
        internal DbSet<TEntity> DbSet;

        public SmartApiRepository(SmartApiFacade smartApiFacade)
        {
            this._smartApiFacade = smartApiFacade;
            this.DbSet = smartApiFacade.Set<TEntity>();
        }

        public void Insert(TEntity entityToAdd)
        {
            this.DbSet.Add(entityToAdd);
        }

        public void Update(TEntity entityToUpdate)
        {
            this.DbSet.Attach(entityToUpdate);
            this._smartApiFacade.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entityToDelete = this.DbSet.Find(id);

            if (entityToDelete != null)
                this.Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (this._smartApiFacade.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.DbSet.Attach(entityToDelete);
            }

            this.DbSet.Remove(entityToDelete);
        }

        public void RemoveRange(IEnumerable<TEntity> entitiesToRemove)
        {
            this.DbSet.RemoveRange(entitiesToRemove);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await this.DbSet.FindAsync(id);
        }

        public async Task<IList<TEntity>> GetAllAsync(int pageIndex, int pageSize, string includeProperties = "")
        {
            IQueryable<TEntity> query = this.DbSet;

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (pageSize > 0)
                query = query.OrderBy(q => q.Id).Skip(pageIndex * pageSize).Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task<IList<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = this.DbSet;

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }
    }
}