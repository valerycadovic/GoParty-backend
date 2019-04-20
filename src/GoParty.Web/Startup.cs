using System;
using System.DirectoryServices;
using System.Web.Http;
using GoParty.Business.Contract.Users.Models;
using GoParty.Web.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Owin;

[assembly: OwinStartup(typeof(GoParty.Web.Startup))]

namespace GoParty.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            NinjectWebCommon.Start(config);

            ConfigureAuth(app);

            SwaggerConfig.Register(config);
            WebApiConfig.Register(config);
            MapperConfig.Configure();

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            var oauthOptions = new OAuthAuthorizationServerOptions
            {
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOauthProvider(
                    NinjectWebCommon.ApplicationKernel.Get<UserManager<User, Guid>>())
            };

            app.UseOAuthAuthorizationServer(oauthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
