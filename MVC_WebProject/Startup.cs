using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_WebProject.Startup))]
namespace MVC_WebProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
