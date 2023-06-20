using BookStoreAPI.Core.DTO;
using BookStoreAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.IService
{
    public interface IBookService
    {
        Task<bool> CreateBook(Book book);
        Task<IEnumerable<Book>> GetAllBook();
        Task<BookDetailDTO> GetBookById(string bookId);
        Task<IEnumerable<Book>> GetBookByName(string bookName);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(string bookId);
    }
}
