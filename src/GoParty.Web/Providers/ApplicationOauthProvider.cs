using System;
using System.Security.Claims;
using System.Threading.Tasks;
using GoParty.Business.Contract.Users.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;

namespace GoParty.Web.Providers
{
    public class ApplicationOauthProvider : OAuthAuthorizationServerProvider
    {
        private readonly UserManager<User, Guid> _userManager;

        public ApplicationOauthProvider(UserManager<User, Guid> userManager)
        {
            _userManager = userManager;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            User user = await _userManager.FindAsync(context.UserName, context.Password);

            if (user is null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

            context.Validated(identity);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return Task.FromResult(0);
        }
    }
}