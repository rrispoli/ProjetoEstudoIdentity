using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Context;
using ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Model;
using ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Provider;
using System;

namespace ProjetoEstudoIdentity.Services.API
{
    public partial class Startup
    {
        static Startup()
        {
            UserManagerFactory = () => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }

        public static Func<UserManager<ApplicationUser>> UserManagerFactory { get; set; }
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
                Provider = new ApplicationOAuthProvider(PublicClientId, UserManagerFactory)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthAuthorizationServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}