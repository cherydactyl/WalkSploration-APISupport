using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WalkSploration.Startup))]
namespace WalkSploration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
