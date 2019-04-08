using System.Web.Http;

namespace GoParty.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            MapperConfig.Configure();
        }
    }
}
