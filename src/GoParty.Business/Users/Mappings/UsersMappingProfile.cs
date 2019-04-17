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
            CreateMap<UserEntity, User>();

            CreateMap<UserEntity, ShortUser>();

            this.CreateMapFromId<Guid, UserEntity>();
        }
    }
}
