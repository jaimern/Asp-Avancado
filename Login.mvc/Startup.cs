using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Login.mvc.Startup))]
namespace Login.mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
