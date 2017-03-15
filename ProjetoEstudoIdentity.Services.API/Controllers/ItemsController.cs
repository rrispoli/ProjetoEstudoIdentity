using ProjetoEstudoIdentity.Domain.Entities;
using ProjetoEstudoIdentity.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace ProjetoEstudoIdentity.Services.API.Controllers
{
    //[Authorize]
    public class ItemsController : ApiController
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET api/items
        public List<Item> Get()
        {
            return _itemService.List();
        }
    }
}