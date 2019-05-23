using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SPTSR.Startup))]
namespace SPTSR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
