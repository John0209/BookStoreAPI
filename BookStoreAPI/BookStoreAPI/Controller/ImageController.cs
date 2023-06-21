using AutoMapper;
using BookStoreAPI.Core.DTO;
using BookStoreAPI.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service.IService;

namespace BookStoreAPI.Controller
{
    [Route("api/image")]
    [ApiController]
    public class ImageControllerr : ControllerBase
    {
        IImageService _image;
        IMapper _map;
        public ImageControllerr(IImageService image,IMapper mapper)
        {
            _image = image;
            _map = mapper;
        }

        [HttpGet("getImage")]
        public async Task<IActionResult> GetImage(string bookId)
        {
            var respone = await _image.GetAllImage(bookId);
            if (respone != null)
            {
                return Ok(respone);
            }
            return BadRequest();
        }
        [HttpPost("addImage")]
        public async Task<IActionResult> AddImage(ImageDTO imageDTO)
        {
            if (imageDTO != null)
            {
                var image = _map.Map<ImageBook>(imageDTO);
                var result = await _image.CreateImage(image);
                if (result) return Ok("Add Image Success");
            }
            return BadRequest("Add Image Fail");
        }
    }
}
