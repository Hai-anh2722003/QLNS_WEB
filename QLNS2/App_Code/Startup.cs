using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLNS2.Startup))]
namespace QLNS2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
