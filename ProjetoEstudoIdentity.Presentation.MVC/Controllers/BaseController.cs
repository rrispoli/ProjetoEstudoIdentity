using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Configuration;
using System.Web;
using System.Web.Mvc;

namespace ProjetoEstudoIdentity.Presentation.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ApplicationUserManager UserManager;
        protected ApplicationSignInManager SignInManager;
        protected const string XsrfKey = "XsrfId";

        public BaseController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        protected void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        protected bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
                return user.PasswordHash != null;
            return false;
        }

        protected bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
                return user.PhoneNumber != null;
            return false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (UserManager != null)
                {
                    UserManager.Dispose();
                    UserManager = null;
                }

                if (SignInManager != null)
                {
                    SignInManager.Dispose();
                    SignInManager = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}