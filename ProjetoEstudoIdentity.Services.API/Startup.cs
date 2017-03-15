using Microsoft.Owin;
using Owin;
using ProjetoEstudoIdentity.Services.API;
using System.Web.Http;

[assembly: OwinStartup(typeof(Startup))]
namespace ProjetoEstudoIdentity.Services.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            SimpleInjectorInitializer.Register(config);
            ConfigureAuth(app);
            WebApiConfig.Register(config);      
            app.UseWebApi(config);    
        }
    }
}