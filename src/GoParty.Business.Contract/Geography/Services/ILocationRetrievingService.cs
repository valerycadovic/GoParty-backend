using System.Collections.Generic;
using System.Threading.Tasks;
using GoParty.Business.Contract.Geography.Models;

namespace GoParty.Business.Contract.Geography.Services
{
    public interface ILocationRetrievingService
    {
        Task<Location> GetById(int id);

        Task<IEnumerable<Country>> GetCountries();

        Task<IEnumerable<Region>> GetRegions(short countryId);

        Task<IEnumerable<City>> GetCities(int regionId);
    }
}
