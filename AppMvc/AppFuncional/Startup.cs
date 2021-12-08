using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppFuncional.Startup))]
namespace AppFuncional
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
