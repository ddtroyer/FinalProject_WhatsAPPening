using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalProject_WhatsAPPening.Startup))]
namespace FinalProject_WhatsAPPening
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
