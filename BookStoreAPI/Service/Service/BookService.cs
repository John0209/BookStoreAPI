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
        Book m_book;
        
        public BookService(IUnitOfWorkRepository unit, ICategoryRepository cate)
        {
            _unit = unit;
            _cate = cate;
            m_book = new Book();
        }
        public async Task<bool> CreateBook(Book book)
        {
            if (book != null)
            {
                var m_list = await GetAllBook();
                book.Book_Id = Guid.NewGuid();
                book.Is_Book_Status= true;
                await _unit.Books.Add(book);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }

        public async Task<bool> DeleteBook(Guid bookId)
        {
            var m_update = _unit.Books.SingleOrDefault(m_book, u => u.Book_Id==bookId);
            if (m_update != null)
            {
                m_update.Is_Book_Status = false;
                _unit.Books.Update(m_update);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
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

        public async Task<BookDetailDTO> GetBookById(Guid bookId)
        {
            var result=await _unit.Books.GetById(bookId);
            var listCate = await _cate.GetAll();
            if (result != null)
            {
                var bookDetail = new BookDetailDTO();
                //lấy thuộc tính gắn vào book detail
                bookDetail.Book_Id = result.Book_Id;
                bookDetail.Book_Title = result.Book_Title;
                bookDetail.Book_Description = result.Book_Description;
                bookDetail.Category_Id=result.Category_Id;
                bookDetail.Category_Name = GetCategoryName(bookDetail, result,listCate);
                bookDetail.Book_Author= result.Book_Author;
                bookDetail.Book_Price= result.Book_Price;
                bookDetail.Book_Quantity= result.Book_Quantity;
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

        public async Task<bool> UpdateBook(Book book)
        {
            var m_update = _unit.Books.SingleOrDefault(m_book, u => u.Book_Id == book.Book_Id);
            if (m_update != null)
            {
                m_update.Category_Id= book.Category_Id;
                m_update.Book_Title= book.Book_Title;
                m_update.Book_Author= book.Book_Author;
                m_update.Book_Price= book.Book_Price;
                m_update.Book_Description= book.Book_Description;
                m_update.Book_Price=book.Book_Price;
                m_update.Book_Year_Public= book.Book_Year_Public;
                m_update.Is_Book_Status= book.Is_Book_Status;
                _unit.Books.Update(m_update);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }

        public async Task<bool> RestoreBook(Guid bookId)
        {
            var m_update = _unit.Books.SingleOrDefault(m_book, u => u.Book_Id == bookId);
            if (m_update != null)
            {
                m_update.Is_Book_Status = true;
                _unit.Books.Update(m_update);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }
    }
}
