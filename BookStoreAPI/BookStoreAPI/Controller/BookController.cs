using AutoMapper;
using BookStoreAPI.Core.DTO;
using BookStoreAPI.Core.Interface;
using BookStoreAPI.Core.Model;
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
        IMapper _mapper;
        public BookController(IBookService book, IMapper mapper) 
        {
            _book = book;
            _mapper = mapper;
        }
        
        [HttpGet("getBook")]
        public async Task<IActionResult> GetAllBook()
        {
                var respone= await _book.GetAllBook();
                if(respone != null)
                {
                var book=_mapper.Map<IEnumerable<BookDetailDTO>>(respone);
                    return Ok(book);
                }
            return BadRequest("null");
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
        [HttpPut("updateBook")]
        public async Task<IActionResult> UpdateBook(BookDetailDTO bookDTO)
        {
            if (bookDTO != null)
            {
                var book = _mapper.Map<Book>(bookDTO);
                var result = await _book.UpdateBook(book);
                if (result) return Ok("Update Book Success");
            }
            return BadRequest("Update Book Fail");
        }
        [HttpDelete("deleteBook")]
        public async Task<IActionResult> DeleteBook(string bookId)
        {
                var result = await _book.DeleteBook(bookId);
                if (result) return Ok("Delete Book Success");
                 return BadRequest("Delete Book Fail");
        }
        [HttpPost("createBook")]
        public async Task<IActionResult> CreateBook(BookDetailDTO dTO)
        {
            if (dTO != null)
            {
                var book = _mapper.Map<Book>(dTO);
                var result = await _book.CreateBook(book);
                if (result) return Ok("Create Book Success");
            }
            return BadRequest("Create Book Fail");
        }
    }
}
