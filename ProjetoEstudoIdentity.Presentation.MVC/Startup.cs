using Microsoft.Owin;
using Owin;
using ProjetoEstudoIdentity.Presentation.MVC;

[assembly: OwinStartup(typeof(Startup))]
namespace ProjetoEstudoIdentity.Presentation.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}