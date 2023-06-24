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
        IRequestService _request;
        IMapper _map;
        public RequestController(IRequestService request, IMapper mapper)
        {
            _request=request;
            _map = mapper;
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
    }
}
