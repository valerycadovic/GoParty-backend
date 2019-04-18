using System;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using GoParty.Business.Contract.Users.Models;
using GoParty.Web.Models;
using Microsoft.AspNet.Identity;
using Ninject;

namespace GoParty.Web.Controllers
{
    public class AccountController : ApiController
    {
        [Inject]
        public UserManager<User, Guid> UserManager { get; set; }

        [HttpPost]
        public async Task<IHttpActionResult> Register([FromBody] RegisterModel model)
        {
            User user = Mapper.Map<RegisterModel, User>(model);

            IdentityResult result = await UserManager.CreateAsync(user, user.Password);

            if (result.Succeeded)
            {
                return Redirect("/api/login/account");
            }

            foreach (var resultError in result.Errors)
            {
                ModelState.AddModelError(string.Empty, resultError);
            }

            return BadRequest(ModelState);
        }
    }
}