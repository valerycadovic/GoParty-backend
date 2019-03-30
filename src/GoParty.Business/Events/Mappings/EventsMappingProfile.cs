using AutoMapper;
using EventData = Repository.Contract.Entities.EventEntity;
using EventView = GoParty.Business.Contract.Events.Models.Event;

namespace GoParty.Business.Events.Mappings
{
    public sealed class EventsMappingProfile : Profile
    {
        
        public EventsMappingProfile()
        {
            CreateMap<EventData, EventView>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(e => e.City))
                .ForMember(dest => dest.PhotoPath, opt => opt.MapFrom(e => e.Image.Name))
                .ForMember(dest => dest.QuantityJoined, opt => opt.Ignore());

            CreateMap<EventView, EventData>();
        }
    }
}
