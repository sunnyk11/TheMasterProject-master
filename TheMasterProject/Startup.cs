using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheMasterProject.Startup))]
namespace TheMasterProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
