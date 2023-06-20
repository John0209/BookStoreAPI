using BookStoreAPI.Core.DTO;
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
        IUnitOfWorkRepository _unit;
        ICategoryRepository _cate;
        
        public BookService(IUnitOfWorkRepository unit, ICategoryRepository cate)
        {
            _unit = unit;
            _cate = cate;
        }
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
            var result = _unit.Books.GetAll();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<BookDetailDTO> GetBookById(string bookId)
        {
            var result=await _unit.Books.GetById(bookId);
            var listCate = await _cate.GetAll();
            if (result != null)
            {
                var bookDetail = new BookDetailDTO();
                //lấy thuộc tính gắn vào book detail
                bookDetail.Book_Id = bookId;
                bookDetail.Book_Title = result.Book_Title;
                bookDetail.Book_Description = result.Book_Description;
                bookDetail.Category_Name = GetCategoryName(bookDetail, result,listCate);
                bookDetail.Book_Author= result.Book_Author;
                bookDetail.Book_Price= result.Book_Price;
                bookDetail.Book_Year_Public= result.Book_Year_Public;
                bookDetail.Book_ISBN= result.Book_ISBN;
                bookDetail.Is_Book_Status= result.Is_Book_Status;
                return bookDetail;
            }
            return null;
        }
        private string GetCategoryName(BookDetailDTO dTO, Book book,IEnumerable<Category> listCate)
        {
            dTO.Category_Name=(from c in listCate where c.Category_Id==book.Category_Id select c.Category_Name).FirstOrDefault();
            return dTO.Category_Name;
        }

        public async Task<IEnumerable<Book>> GetBookByName(string bookName)
        {
            //var result = await _unit.Books.GetByName(bookName);
            var books = await GetAllBook();
            var result = from b in books where (b.Book_Title.ToLower().Trim().Contains(bookName.ToLower().Trim())) select b;
            if (result.Count()>0)
            {
                return result;
            }
            return null;
        }

        public Task<bool> UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
