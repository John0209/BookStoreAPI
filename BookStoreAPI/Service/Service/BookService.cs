using BookStoreAPI.Core.Interface;
using BookStoreAPI.Core.Model;
using Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class BookService : IBookService
    {
        public Task<bool> CreateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBook(string bookId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAllBook()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookById(string bookId)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookByName(string bookName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
