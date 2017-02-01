using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TempleProject.Startup))]
namespace TempleProject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
