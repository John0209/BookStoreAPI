using AutoMapper;
using BookStoreAPI.Core.DTO;
using BookStoreAPI.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service.IService;
using static System.Net.Mime.MediaTypeNames;

namespace BookStoreAPI.Controller
{
    [Route("api/request")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        //Cộng quantity khi import thành công, status order, order trừ quantity book

        IRequestService _request;
        IMapper _map;
        public RequestController(IRequestService request, IMapper mapper)
        {
            _request=request;
            _map = mapper;
        }
        [HttpPut("updateRequest")]
        public async Task<IActionResult> UpdateRequest(RequestDTO requestDTO)
        {
            if (requestDTO != null)
            {
                var request = _map.Map<BookingRequest>(requestDTO);
                var result = await _request.UpdateRequest(request);
                if (result) return Ok("Update Request Success");
            }
            return BadRequest("Update Request Fail");
        }
        [HttpGet("getRequest")]
        public async Task<IActionResult> GetRequest()
        {
            var respone = await _request.GetAllRequest();
            if (respone.Count()>0)
            {
                return Ok(respone);
            }
            return BadRequest("null");
        }
        [HttpPost("createRequest")]
        public async Task<IActionResult> CreateRequest(RequestDTO dto)
        {
            if (dto != null)
            {
                var request=_map.Map<BookingRequest>(dto);
                var result = await _request.CreateRequest(request);
                if (result) return Ok("Add Request Success");
            }
            return BadRequest("Add Request Fail");
        }
        [HttpPatch("deleteRequest")]
        public async Task<IActionResult> DeleteRequest(Guid requestId)
        {
            var result = await _request.DeleteRequest(requestId);
            if (result) return Ok("Delete Request Success");
            return BadRequest("Delete Request Fail");
        }
        [HttpPatch("restoreRequest")]
        public async Task<IActionResult> RestoreRequest(Guid requestId)
        {
            var result = await _request.RestoreRequest(requestId);
            if (result) return Ok("Restore Request Success");
            return BadRequest("Restore Request Fail");
        }
    }
}
