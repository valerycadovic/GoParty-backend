using System;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using GoParty.Business.Contract.Users.Models;
using GoParty.Business.Contract.Users.Services;
using GoParty.Web.Models;
using Microsoft.AspNet.Identity;
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
        public UserManager<User, Guid> UserManager { get; set; }

        #endregion

        [HttpGet]
        [Route("{userId:guid}")]
        public async Task<ProfileModel> GetUserProfile(Guid userId)
        {
            User user = await UserRetrievingService.GetById(userId);

            ProfileModel profile = Mapper.Map<User, ProfileModel>(user);

            SetIsSelf(profile);

            return profile;
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<ProfileModel> Edit([FromBody] ProfileModel editModel)
        {
            User user = await UserRetrievingService.GetByUserName(User.Identity.Name);

            if (editModel.Id != user.Id)
            {
                throw new InvalidOperationException("You cannot edit current profile");
            }

            User editedUser = Mapper.Map(editModel, user);

            await UserManager.UpdateAsync(editedUser);

            return editModel;
        }

        private void SetIsSelf(ProfileModel profileModel)
        {
            if (profileModel.UserName == User.Identity.Name)
            {
                profileModel.IsSelf = true;
            }
        }
    }
}