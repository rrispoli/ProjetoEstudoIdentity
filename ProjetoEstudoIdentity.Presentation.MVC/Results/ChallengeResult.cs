using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;

namespace ProjetoEstudoIdentity.Presentation.MVC.Results
{
    public class ChallengeResult : HttpUnauthorizedResult
    {
        public ChallengeResult(string provider, string redirectUri, string xsrfKey) : this(provider, redirectUri, xsrfKey, null)
        {
        }

        public ChallengeResult(string provider, string redirectUri, string xsrfKey, string userId) 
        {
            LoginProvider = provider;
            RedirectUri = redirectUri;
            UserId = userId;
        }
        
        public string LoginProvider { get; set; }
        public string RedirectUri { get; set; }
        public string UserId { get; set; }
        public string XsrfKey { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
            if (UserId != null)
            {
                properties.Dictionary[XsrfKey] = UserId;
            }
            context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
        }
    }
}