using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MacroMinder.Startup))]
namespace MacroMinder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
