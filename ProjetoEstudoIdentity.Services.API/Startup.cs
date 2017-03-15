using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Provider;
using ProjetoEstudoIdentity.Services.API;
using System;

[assembly: OwinStartup(typeof(Startup))]
namespace ProjetoEstudoIdentity.Services.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }
    }
}