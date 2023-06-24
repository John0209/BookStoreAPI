using AutoMapper;
using BookStoreAPI.Core.DTO;
using BookStoreAPI.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service;
using Service.Service.IService;
using static System.Net.Mime.MediaTypeNames;

namespace BookStoreAPI.Controller
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _order;
        IMapper _map;
        public OrderController(IOrderService order, IMapper mapper)
        {
            _map = mapper;
            _order = order;
        }
        [HttpGet("getOrder")]
        public async Task<IActionResult> GetOrder()
        {
            var respone = await _order.GetAllOrder();
            if (respone != null)
            {
                var result= _map.Map<IEnumerable<OrderDTO>>(respone);
                return Ok(result);
            }
            return BadRequest("order don't exists");
        }
        [HttpPost("createOrder")]
        public async Task<IActionResult> CreateOrder(OrderDTO dto)
        {
            if (dto != null)
            {
                var order=_map.Map<Order>(dto);
                var result = await _order.CreateOrder(order);
                if (result) return Ok("Add Order Success");
            }
            return BadRequest("Add Order Fail");
        }
        [HttpDelete("deleteOrder")]
        public async Task<IActionResult> DeleteOrder(string orderId)
        {
            var result = await _order.DeleteOrder(orderId);
            if (result) return Ok("Delete Order Success");
            return BadRequest("Delete Order Fail");
        }
        [HttpPut("updateOrder")]
        public async Task<IActionResult> UpdateOrder(OrderDTO dto)
        {
            if (dto != null)
            {
                var order = _map.Map<Order>(dto);
                var result = await _order.UpdateOrder(order);
                if (result) return Ok("Update Order Success");
            }
            return BadRequest("Update Order Fail");
        }
    }
}
