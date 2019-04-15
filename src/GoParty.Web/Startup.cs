using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
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
        }
    }
}
