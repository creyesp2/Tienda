using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperTienda.Startup))]
namespace SuperTienda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
