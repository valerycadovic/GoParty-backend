using Repository.Contexts;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;
using Repository.Repositories.Base;

namespace Repository.Repositories
{
    public class CountryRepository : EntityRepository<CountryEntity, short>, ICountryRepository
    {
        public CountryRepository(GoPartyDbContext context) : base(context)
        {
        }
    }
}
