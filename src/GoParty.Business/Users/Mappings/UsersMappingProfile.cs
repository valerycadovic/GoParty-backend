using System;
using AutoMapper;
using GoParty.Business.Contract.Users.Models;
using GoParty.Business.Core.Extensions;
using Repository.Contract.Entities;

namespace GoParty.Business.Users.Mappings
{
    public sealed class UsersMappingProfile : Profile
    {
        public UsersMappingProfile()
        {
            CreateMap<UserEntity, User>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.City));

            CreateMap<UserEntity, ShortUser>();

            this.CreateMapFromId<Guid, UserEntity>();
        }
    }
}
