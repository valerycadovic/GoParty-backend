using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using GoParty.Web.Handlers;

namespace GoParty.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Services.Replace(typeof(IExceptionHandler), new WebApiExceptionHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
