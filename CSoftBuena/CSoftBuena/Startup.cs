using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSoftBuena.Startup))]
namespace CSoftBuena
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
