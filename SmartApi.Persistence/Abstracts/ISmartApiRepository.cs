using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartApi.Shared.Dtos;

namespace SmartApi.Persistence.Abstracts
{
    public interface ISmartApiRepository<TEntity> where TEntity : DtoBase
    {
        void Insert(TEntity entityToAdd);
        void Update(TEntity entityToUpdate);
        void Delete(int id);
        void Delete(TEntity entityToDelete);
        void RemoveRange(IEnumerable<TEntity> entitiesToRemove);

        Task<TEntity> GetByIdAsync(int id);
        Task<IList<TEntity>> GetAllAsync(int pageIndex, int pageSize, string includeProperties = "");
        Task<IList<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
    }
}
