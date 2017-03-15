using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}