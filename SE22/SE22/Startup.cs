using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SE22.Startup))]
namespace SE22
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
