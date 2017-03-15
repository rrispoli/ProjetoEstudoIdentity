using ProjetoEstudoIdentity.Domain.Entities;
using ProjetoEstudoIdentity.Domain.Interfaces.Repositories;
using ProjetoEstudoIdentity.Domain.Interfaces.Services;

namespace ProjetoEstudoIdentity.Domain.Services
{
    public class ItemService : ServiceBase<Item>, IItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}