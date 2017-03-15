using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Configuration;
using ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Provider;
using System;
using System.Web.Http;

namespace ProjetoEstudoIdentity.Services.API
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthAuthorizationServerOptions { get; private set; }
        public static string PublicClientId { get; private set; }

        public void ConfigureOAuth(IAppBuilder app)
        {
            PublicClientId = "self";
            OAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(30),
                Provider = new ApplicationOAuthProvider(PublicClientId)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthAuthorizationServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}