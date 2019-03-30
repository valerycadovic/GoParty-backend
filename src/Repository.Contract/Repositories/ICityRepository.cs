using System.Threading.Tasks;
using Repository.Contract.Entities;
using Repository.Contract.Repositories.Base;

namespace Repository.Contract.Repositories
{
    public interface ICityRepository : IEntityRepository<CityEntity, int>
    {
    }
}
