using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RRHH.UI.Startup))]
namespace RRHH.UI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
