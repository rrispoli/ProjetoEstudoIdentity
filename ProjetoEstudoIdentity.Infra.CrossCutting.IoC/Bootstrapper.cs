using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjetoEstudoIdentity.Domain.Interfaces.Repositories;
using ProjetoEstudoIdentity.Domain.Interfaces.Services;
using ProjetoEstudoIdentity.Domain.Services;
using ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Configuration;
using ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Context;
using ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Model;
using ProjetoEstudoIdentity.Infra.Data.Repositories;
using SimpleInjector;

namespace ProjetoEstudoIdentity.Infra.CrossCutting.IoC
{
    public class Bootstrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);

            container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<IItemService, ItemService>(Lifestyle.Scoped);

            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IItemRepository, ItemRepository>(Lifestyle.Scoped);
        }
    }
}