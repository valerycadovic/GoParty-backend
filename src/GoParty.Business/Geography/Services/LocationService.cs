using System.Collections.Generic;
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

        public async Task<Location> GetById(int id)
        {
            CityEntity city = await _cityRepository.GetByIdAsync(id);

            return Mapper.Map<CityEntity, Location>(city);
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            IEnumerable<CountryEntity> countries = await _countryRepository.GetAllAsync();

            return countries.Select(Mapper.Map<CountryEntity, Country>);
        }

        public async Task<IEnumerable<Region>> GetRegions(short countryId)
        {
            IEnumerable<RegionEntity> regions = await _regionRepository.GetAsync(r => r.Country.Id == countryId);

            return regions.Select(Mapper.Map<RegionEntity, Region>);
        }

        public async Task<IEnumerable<City>> GetCities(int regionId)
        {
            IEnumerable<CityEntity> cities = await _cityRepository.GetAsync(c => c.Region.Id == regionId);

            return cities.Select(Mapper.Map<CityEntity, City>);
        }
    }
}
