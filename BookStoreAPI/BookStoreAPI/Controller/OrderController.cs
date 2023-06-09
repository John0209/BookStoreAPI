﻿using AutoMapper;
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
        [HttpGet("getOrderByUserId")]
        public async Task<IActionResult> GetOrderByUserId(Guid UserId)
        {
            var respone = await _order.GetOrderByUserId(UserId);
            if (respone != null)
            {
                var result = _map.Map<IEnumerable<OrderDTO>>(respone);
                return Ok(result);
            }
            return BadRequest("order don't exists");
        }
        [HttpGet("getOrderByOrderId")]
        public async Task<IActionResult> GetOrderByOrderId(Guid OrderId)
        {
            var respone = await _order.GetOrderByOrderId(OrderId);
            if (respone != null)
            {
                var result = _map.Map<OrderDTO>(respone);
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
        [HttpPatch("deleteOrder")]
        public async Task<IActionResult> DeleteOrder(Guid orderId)
        {
            var result = await _order.DeleteOrder(orderId);
            if (result) return Ok("Delete Order Success");
            return BadRequest("Delete Order Fail");
        }
        [HttpPatch("restoreOrder")]
        public async Task<IActionResult> RestoreOrder(Guid orderId)
        {
            var result = await _order.RestoreOrder(orderId);
            if (result) return Ok("Restore Order Success");
            return BadRequest("Restore Order Fail");
        }
        [HttpDelete("removeOrder")]
        public async Task<IActionResult> RemoveOrder(Guid orderId)
        {
            var result = await _order.RemoveOrder(orderId);
            if (result) return Ok("Remove Order Success");
            return BadRequest("Remove Order Fail");
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
