using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgenciaViajesKarinaHeras.Startup))]
namespace AgenciaViajesKarinaHeras
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
