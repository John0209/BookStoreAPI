using BookStoreAPI.Core.DTO;
using BookStoreAPI.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service.IService;

namespace BookStoreAPI.Controller
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookService _book;
        public BookController(IBookService book) 
        {
            _book = book;
        }
        
        [HttpGet("getBook")]
        public async Task<IActionResult> GetAllBook()
        {
                var respone= await _book.GetAllBook();
                if(respone != null)
                {
                    return Ok(respone);
                }
            return BadRequest();
        }
        [HttpGet("searchBook")]
        public async Task<IActionResult> SearchBook(string nameBook)
        {
            var respone = await _book.GetBookByName(nameBook);
            if (respone != null)
            {
                return Ok(respone);
            }
            return BadRequest("Book don't exists");
        }
        [HttpGet("getBookDetail")]
        public async Task<IActionResult> GetBookDetail(string bookId)
        {
            var respone = await _book.GetBookById(bookId);
            if (respone != null)
            {
                return Ok(respone);
            }
            return BadRequest("Book don't exists");
        }
    }
}
