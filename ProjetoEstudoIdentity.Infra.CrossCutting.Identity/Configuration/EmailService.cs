using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Configuration
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Habilitar o envio de e-mail

            return Task.FromResult(0);
        }
    }
}