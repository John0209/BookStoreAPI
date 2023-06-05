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
        Task<Book> GetBookById(string bookId);
        Task<Book> GetBookByName(string bookName);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(string bookId);
    }
}
