using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Feb8.Startup))]
namespace Feb8
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
