﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Repository.Contract.Repositories.Base;

namespace Repository.Repositories.Base
{
    public abstract class AbstractRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public abstract IQueryable<TEntity> GetAll();

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return GetAll().Where(filter);
        }

        public abstract Task AddAsync(TEntity entity);

        public abstract Task UpdateAsync(TEntity entity);

        public abstract Task DeleteAsync(TEntity entity);

        public abstract Task AddRangeAsync(IEnumerable<TEntity> entities);

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await GetAll().CountAsync(filter);
        }

        public async Task<int> CountAsync()
        {
            return await GetAll().CountAsync();
        }
    }
}
