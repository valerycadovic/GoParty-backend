using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using GoParty.Business.Contract.Geography.Models;
using GoParty.Business.Contract.Geography.Services;
using Ninject;

namespace GoParty.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/Geography")]
    public class GeographyController : ApiController
    {
        [Inject]
        public ILocationRetrievingService LocationRetrievingService { get; set; }

        [HttpGet]
        [Route("Countries")]
        public async Task<List<Country>> GetAll()
        {
            return await LocationRetrievingService.GetCountries();
        }

        [HttpGet]
        [Route("Regions/{countryId}")]
        public async Task<List<Region>> GetRegionsByCountry([FromUri] short countryId)
        {
            return await LocationRetrievingService.GetRegions(countryId);
        }

        [HttpGet]
        [Route("Cities/{regionId}")]
        public async Task<List<City>> GetCitiesByRegion([FromUri] int regionId)
        {
            return await LocationRetrievingService.GetCities(regionId);
        }
    }
}