using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GoParty.Business.Contract.Core.Exceptions;
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

            if (city == null)
            {
                throw new MessageException("Current location not exists");
            }

            return Mapper.Map<CityEntity, Location>(city);
        }

        public async Task<List<Country>> GetCountries()
        {
            List<CountryEntity> countries = await _countryRepository.GetAll().ToListAsync();

            return countries.Select(Mapper.Map<CountryEntity, Country>).ToList();
        }

        public async Task<List<Region>> GetRegions(short countryId)
        {
            List<RegionEntity> regions = await _regionRepository.Get(r => r.Country.Id == countryId).ToListAsync();
            
            return regions.Select(Mapper.Map<RegionEntity, Region>).ToList();
        }

        public async Task<List<City>> GetCities(int regionId)
        {
            var cities = await _cityRepository.Get(c => c.Region.Id == regionId).ToListAsync();

            return cities.Select(Mapper.Map<CityEntity, City>).ToList();
        }
    }
}
