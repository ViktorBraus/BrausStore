using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebUA1.Startup))]
namespace WebUA1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
