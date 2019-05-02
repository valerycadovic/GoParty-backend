using AutoMapper;
using GoParty.Business.Contract.Users.Models;
using GoParty.Web.Models;

namespace GoParty.Web.Mappers
{
    public class RegisterModelMappingProfile : Profile
    {
        public RegisterModelMappingProfile()
        {
            CreateMap<RegisterModel, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<User, ProfileModel>()
                .ForMember(dest => dest.IsSelf, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}