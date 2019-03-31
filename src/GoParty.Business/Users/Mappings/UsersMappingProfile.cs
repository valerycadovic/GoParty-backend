using AutoMapper;
using UserData = Repository.Contract.Entities.UserEntity;
using UserView = GoParty.Business.Contract.Users.Models.User;
using ShortUserView = GoParty.Business.Contract.Users.Models.ShortUser;

namespace GoParty.Business.Users.Mappings
{
    public sealed class UsersMappingProfile : Profile
    {
        public UsersMappingProfile()
        {
            CreateMap<UserData, UserView>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(e => e.Image.Name))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(e => e.Login));

            CreateMap<UserData, ShortUserView>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(e => e.Image.Name))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(e => e.Login));
        }
    }
}
