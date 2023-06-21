using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service.IService;

namespace BookStoreAPI.Controller
{
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        IInventoryService _inventory;
        IMapper _map;
        public InventoryController(IInventoryService inventory,IMapper mapper)
        {
            _inventory = inventory;
            _map = mapper;
        }
        [HttpGet("getInventory")]
        public async Task<IActionResult> GetInventory()
        {
            var respone = await _inventory.GetAllInventory();
            if (respone != null)
            {
                return Ok(respone);
            }
            return BadRequest("inventory don't exists");
        }
    }
}
