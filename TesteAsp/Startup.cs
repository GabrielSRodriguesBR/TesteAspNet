using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TesteAsp.Startup))]
namespace TesteAsp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
