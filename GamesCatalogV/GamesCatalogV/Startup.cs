using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamesCatalogV.Startup))]
namespace GamesCatalogV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
