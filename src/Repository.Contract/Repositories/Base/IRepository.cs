using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Contract.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);

        Task<int> CountAsync();
    }
}
