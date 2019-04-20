using System;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using GoParty.Business.Contract.Users.Models;
using GoParty.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Ninject;

namespace GoParty.Web.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        [Inject]
        public UserManager<User, Guid> UserManager { get; set; }

        [HttpPost]
        [Route("Register")]
        public async Task<IHttpActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = Mapper.Map<RegisterModel, User>(model);

            IdentityResult result = await UserManager.CreateAsync(user, user.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            foreach (var resultError in result.Errors)
            {
                ModelState.AddModelError(string.Empty, resultError);
            }

            return BadRequest(ModelState);
        }
    }
}