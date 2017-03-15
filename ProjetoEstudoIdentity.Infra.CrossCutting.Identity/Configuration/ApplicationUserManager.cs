using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Model;
using System;

namespace ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Configuration
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
            UserValidator = new UserValidator<ApplicationUser>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            /*UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;

            RegisterTwoFactorProvider("Código via SMS", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Seu código de segurança é: {0}"
            });

            RegisterTwoFactorProvider("Código via E-mail", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Código de Segurança",
                BodyFormat = "Seu código de segurança é: {0}"
            });

            EmailService = new EmailService();

            SmsService = new SmsService();*/

            var provider = new DpapiDataProtectionProvider("ProjetoEstudoIdentity");
            var dataProtector = provider.Create("ASP.NET Identity");

            UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtector);
        }
    }
}