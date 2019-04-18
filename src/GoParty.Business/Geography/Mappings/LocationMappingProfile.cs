using AutoMapper;
using GoParty.Business.Contract.Geography.Models;
using GoParty.Business.Core.Extensions;
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
                .ForMember(dest => dest.City, opt => opt.MapFrom(e => e))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(e => e.Region))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(e => e.Region.Country));

            this.CreateMapFromId<short, CountryEntity>();
            this.CreateMapFromId<int, RegionEntity>();
            this.CreateMapFromId<int, CityEntity>();

            CreateMap<Location, CityEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.City.Id))
                .ForPath(dest => dest.Region, opt => opt.MapFrom(e => e.Region.Id))
                .ForPath(dest => dest.Region.Country, opt => opt.MapFrom(e => e.Country.Id))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
