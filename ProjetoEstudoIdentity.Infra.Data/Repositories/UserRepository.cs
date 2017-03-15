using ProjetoEstudoIdentity.Domain.Entities;
using ProjetoEstudoIdentity.Domain.Interfaces.Repositories;

namespace ProjetoEstudoIdentity.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
    }
}