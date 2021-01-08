using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TheBeholder.Business.Models;
using System.Threading.Tasks;

namespace TheBeholder.Business.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task DeleteAsync(TEntity entity);
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task InsertAsync(TEntity entity);
        Task InsertAsync(IEnumerable<TEntity> entities);
        IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);
        Task UpdateAsync(TEntity entity);
    }
}