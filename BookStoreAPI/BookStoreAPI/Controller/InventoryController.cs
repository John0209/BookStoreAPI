using AutoMapper;
using BookStoreAPI.Core.DTO;
using BookStoreAPI.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service.IService;
using static System.Net.Mime.MediaTypeNames;

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
        [HttpGet("searchInventory")]
        public async Task<IActionResult> SearchInventory(string bookName)
        {
            var respone = await _inventory.SearchInventory(bookName);
            if (respone != null)
            {
                return Ok(respone);
            }
            return BadRequest(bookName+" don't exists");
        }
        [HttpPost("addInventory")]
        public async Task<IActionResult> AddInventory(InventoryDTO dto)
        {
            if (dto != null)
            {
                var inventory=_map.Map<Inventory>(dto);
                var result = await _inventory.CreateInventory(inventory);
                if (result) return Ok("Add Inventory Success");
            }
            return BadRequest("Add Inventory Fail");
        }
        [HttpDelete("deleteInventory")]
        public async Task<IActionResult> DeleteInventory(string inventoryId)
        {
            var result = await _inventory.DeleteInventory(inventoryId);
            if (result) return Ok("Delete Inventory Success");
            return BadRequest("Delete Inventory Fail");
        }
    }
}
