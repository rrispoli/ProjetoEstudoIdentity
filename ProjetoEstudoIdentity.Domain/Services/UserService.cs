using ProjetoEstudoIdentity.Domain.Entities;
using ProjetoEstudoIdentity.Domain.Interfaces.Repositories;
using ProjetoEstudoIdentity.Domain.Interfaces.Services;

namespace ProjetoEstudoIdentity.Domain.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}