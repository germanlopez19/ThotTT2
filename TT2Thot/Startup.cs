using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TT2Thot.Startup))]
namespace TT2Thot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
