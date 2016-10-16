using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sweet.Startup))]
namespace Sweet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
