using System;
using System.DirectoryServices;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(GoParty.Web.Startup))]

namespace GoParty.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            SwaggerConfig.Register(config);
            WebApiConfig.Register(config);
            NinjectWebCommon.Start(config);
            MapperConfig.Configure();

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);

            var oauthOptions = new OAuthAuthorizationServerOptions
            {
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                Provider = new OAuthAuthorizationServerProvider(),
                AuthorizeEndpointPath = new PathString("/api/authorize")
            };
            
            app.UseOAuthAuthorizationServer(oauthOptions);

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
        }
    }
}
