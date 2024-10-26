using Microsoft.AspNetCore.Mvc;
using MiniAKS_Services.Interfaces;

namespace MiniAKS.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _itemService.GetItems();
            return Ok(items);
        }

        [HttpGet("{itemId}")]
        public IActionResult GetItem(Guid itemId)
        {
            var item = _itemService.GetItem(itemId);
            return Ok(item);
        }

        [HttpGet("{itemId}/products")]
        public IActionResult GetProductsByItemId(Guid itemId)
        {
            var itemProducts = _itemService.GetProductsByItemId(itemId);
            return Ok(itemProducts);
        }
    }
}
