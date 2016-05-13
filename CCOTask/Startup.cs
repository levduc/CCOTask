using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CCOTask.Startup))]
namespace CCOTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
