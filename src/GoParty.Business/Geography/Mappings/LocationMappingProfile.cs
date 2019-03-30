using AutoMapper;
using GoParty.Business.Contract.Geography.Models;
using Repository.Contract.Entities;

namespace GoParty.Business.Geography.Mappings
{
    public sealed class LocationMappingProfile : Profile
    {
        public LocationMappingProfile()
        {
            CreateMap<CountryEntity, Country>();
            CreateMap<RegionEntity, Region>();
            CreateMap<CityEntity, City>();

            CreateMap<CityEntity, Location>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(e => e.Name))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(e => e.Region.Name))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(e => e.Region.Country.Name));
        }
    }
}
