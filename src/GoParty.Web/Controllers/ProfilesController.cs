using System;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using GoParty.Business.Contract.Users.Models;
using GoParty.Business.Contract.Users.Services;
using GoParty.Web.Models;
using Ninject;

namespace GoParty.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/Profiles")]
    public class ProfilesController : ApiController
    {
        #region Dependencies

        [Inject]
        public IUserRetrievingService UserRetrievingService { get; set; }

        [Inject]
        public IUserModifyingService UserModifyingService { get; set; }

        #endregion

        [HttpGet]
        [Route("{userId:guid}")]
        public async Task<ProfileModel> GetUserProfile(Guid userId)
        {
            User user = await UserRetrievingService.GetById(userId);

            ProfileModel profile = Mapper.Map<User, ProfileModel>(user);

            if (user.UserName == User.Identity.Name)
            {
                profile.IsSelf = true;
            }

            return profile;
        }
    }
}