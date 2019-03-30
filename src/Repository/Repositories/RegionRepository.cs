using Repository.Contexts;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;
using Repository.Repositories.Base;

namespace Repository.Repositories
{
    public class RegionRepository : EntityRepository<RegionEntity, int>, IRegionRepository
    {
        public RegionRepository(GoPartyDbContext context) : base(context)
        {
        }
    }
}
