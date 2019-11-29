using System.Collections.Generic;
using System.Threading.Tasks;
using GoParty.Business.Contract.Geography.Models;

namespace GoParty.Business.Contract.Geography.Services
{
    public interface ILocationRetrievingService
    {
        Task<Location> GetById(int id);

        Task<List<Country>> GetCountries();

        Task<List<Region>> GetRegions(short countryId);

        Task<List<City>> GetCities(int regionId);
    }
}
