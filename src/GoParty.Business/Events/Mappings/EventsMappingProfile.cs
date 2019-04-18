using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GoParty.Business.Contract.Events.Models;
using GoParty.Business.Events.Models;
using Repository.Contract.Entities;
using GoParty.Business.Core.Extensions;

namespace GoParty.Business.Events.Mappings
{
    public sealed class EventsMappingProfile : Profile
    {
        public EventsMappingProfile()
        {
            CreateMap<EventEntity, Event>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(e => e.City))
                .ForMember(dest => dest.QuantityJoined, opt => opt.Ignore());

            CreateMap<TagEntity, Tag>();
            this.CreateMapFromId<int, TagEntity>();
            
            CreateMap<EventModifying, EventEntity>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(e => DateTime.Now))
                .ForMember(dest => dest.ModifiedOn, opt => opt.MapFrom(e => DateTime.Now))
                .ForMember(dest => dest.City, opt => opt.MapFrom(e => e.Location))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(e => Guid.NewGuid()))
                .ForMember(dest => dest.EventSubscribers, opt => opt.Ignore())
                .ForMember(dest => dest.Comment, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<EventWithQuantity, Event>()
                .ForMember(dest => dest.QuantityJoined, opt => opt.MapFrom(e => e.QuantitySubscribed))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(e => e.Event.City))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(e => e.Event.Address))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(e => e.Event.CreatedBy))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(e => e.Event.Description))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Event.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(e => e.Event.Name))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(e => e.Event.StartTime))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(e => e.Event.Tags));
        }
    }
}
