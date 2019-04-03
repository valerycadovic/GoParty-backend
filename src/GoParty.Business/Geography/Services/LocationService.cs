using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GoParty.Business.Contract.Geography.Models;
using GoParty.Business.Contract.Geography.Services;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;

namespace GoParty.Business.Geography.Services
{
    public class LocationService : ILocationRetrievingService
    {
        #region Dependencies

        private readonly ICityRepository _cityRepository;

        private readonly IRegionRepository _regionRepository;

        private readonly ICountryRepository _countryRepository;
        
        public LocationService(
            ICityRepository cityRepository,
            IRegionRepository regionRepository,
            ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
            _regionRepository = regionRepository;
            _cityRepository = cityRepository;
        }

        #endregion

        public async Task<Location> GetById(int id)
        {
            CityEntity city = await _cityRepository.GetByIdAsync(id);

            return Mapper.Map<CityEntity, Location>(city);
        }

        public async Task<List<Country>> GetCountries()
        {
            var countries = _countryRepository.GetAll();

            return await countries.Select(n => Mapper.Map<CountryEntity, Country>(n)).ToListAsync();
        }

        public async Task<List<Region>> GetRegions(short countryId)
        {
            var regions = _regionRepository.Get(r => r.Country.Id == countryId);

            return await regions.Select(n => Mapper.Map<RegionEntity, Region>(n)).ToListAsync();
        }

        public async Task<List<City>> GetCities(int regionId)
        {
            var cities = _cityRepository.Get(c => c.Region.Id == regionId);

            return await cities.Select(n => Mapper.Map<CityEntity, City>(n)).ToListAsync();
        }
    }
}
