using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vehicles.Backend.Startup))]
namespace Vehicles.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
