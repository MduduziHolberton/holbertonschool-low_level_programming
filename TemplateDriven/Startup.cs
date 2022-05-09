using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TemplateDriven.Startup))]
namespace TemplateDriven
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
