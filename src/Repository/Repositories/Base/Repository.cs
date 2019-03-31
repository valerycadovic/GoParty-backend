using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Repository.Contexts;

namespace Repository.Repositories.Base
{
    public class Repository<TEntity> : AbstractRepository<TEntity> where TEntity : class
    {
        private readonly GoPartyDbContext _context;

        public Repository(GoPartyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException($"{nameof(context)} is null");
        }

        protected DbSet<TEntity> Entities => _context.Set<TEntity>();

        public override IQueryable<TEntity> GetAll()
        {
            return Entities;
        }

        public override async Task AddAsync(TEntity entity)
        {
            await Task.Run(() => Attach(entity, EntityState.Added));
        }

        public override async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => Attach(entity, EntityState.Modified));
        }

        public override async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => Attach(entity, EntityState.Deleted));
        }

        public override async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => Entities.AddRange(entities));
        }

        protected void Attach(TEntity entity, EntityState state)
        {
            Entities.Attach(entity);
            _context.Entry(entity).State = state;
        }
    }
}
