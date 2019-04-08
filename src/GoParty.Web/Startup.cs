using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GoParty.Web.Startup))]

namespace GoParty.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
