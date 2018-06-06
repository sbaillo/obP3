using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Intendencia.Startup))]
namespace Intendencia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
