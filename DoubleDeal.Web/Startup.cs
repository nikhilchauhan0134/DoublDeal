using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoubleDeal.Web.Startup))]
namespace DoubleDeal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
