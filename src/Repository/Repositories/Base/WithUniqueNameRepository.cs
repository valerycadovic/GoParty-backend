using System.Data.Entity;
using System.Threading.Tasks;
using Repository.Contexts;
using Repository.Contract.Entities.Contract;
using Repository.Contract.Repositories.Base;

namespace Repository.Repositories.Base
{
    public class WithUniqueNameRepository<TEntity> : Repository<TEntity>, IWithUniqueNameRepository<TEntity>
        where TEntity : class, IWithUniqueName
    {
        public WithUniqueNameRepository(GoPartyDbContext context) : base(context)
        {
        }

        public async Task<TEntity> GetByNameAsync(string name)
        {
            return await GetAll().SingleOrDefaultAsync(e => e.Name == name);
        }
    }
}
