using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoServis.Startup))]
namespace AutoServis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
