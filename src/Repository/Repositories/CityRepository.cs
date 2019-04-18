using Repository.Contexts;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;
using Repository.Repositories.Base;

namespace Repository.Repositories
{
    public class CityRepository : EntityRepository<CityEntity, int>, ICityRepository
    {
        public CityRepository(GoPartyDbContext context) : base(context)
        {
        }
    }
}
