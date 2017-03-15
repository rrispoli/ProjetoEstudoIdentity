using ProjetoEstudoIdentity.Domain.Entities;
using ProjetoEstudoIdentity.Domain.Interfaces.Repositories;

namespace ProjetoEstudoIdentity.Infra.Data.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
    }
}