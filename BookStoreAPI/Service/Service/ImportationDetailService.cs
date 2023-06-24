using BookStoreAPI.Core.DiplayDTO;
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
    public class ImportationDetailService : IImportationDetailService
    {
        IUnitOfWorkRepository _unit;
        IBookRepository _book;
        IImageBookRepository _imageBook;
        public ImportationDetailService(IUnitOfWorkRepository unitOfWorkRepository, IBookRepository book, 
            IImageBookRepository imageBook)
        {
            _unit = unitOfWorkRepository;
            _book = book;
            _imageBook = imageBook;
        }
        public async Task<bool> CreateImportDetail(ImportationDetail importDetail)
        {
            if (importDetail != null)
            {
                var m_list = await GetAllImportDetail();
                importDetail.Import_Detail_Id = CreateId(m_list);
                await _unit.ImportationDetail.Add(importDetail);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }
        private string CreateId(IEnumerable<ImportationDetail> m_list)
        {
            if (m_list.Count() < 1)
            {
                var id = "IMD1";
                return id;
            }
            var m_id = m_list.LastOrDefault().Import_Detail_Id;
            if (m_id != null)
            {
                var number = Int32.Parse(m_id.Substring(m_id.Length - 1));
                number++;
                var id = "IMD" + number;
                return id;
            }
            return null;
        }

        public async Task<IEnumerable<ImportationDetail>> GetAllImportDetail()
        {
            var result = await _unit.ImportationDetail.GetAll();
            if (result != null)
            {
                return result;
            }
            return null;
        }
        public async Task<IEnumerable<DiplayImportationDetailDTO>> GetDiplayImportDetail()
        {
            var importList= await _unit.ImportationDetail.GetAll();
            var bookList= await _unit.Books.GetAll();
            var image= await _unit.Images.GetAll();
            // get filed để display
            var display= new List<DiplayImportationDetailDTO>();
            foreach ( var item in importList)
            {
                var import= new DiplayImportationDetailDTO();
                import.Import_Detail_Quantity=item.Import_Detail_Quantity;
                import.Import_Detail_Price=item.Import_Detail_Price;
                import.Import_Detail_Amount=item.Import_Detail_Amount;
                import.Book_Title = GetTitle(item.Book_Id, bookList);
                import.Image_URL = GetUrl(item.Book_Id, image);
                display.Add(import);
            }
            if (display.Count < 1) return null;
            return display;

        }

        private string GetUrl(string book_Id, IEnumerable<ImageBook> image)
        {
            var url = (from b in image where b.Book_Id == book_Id select b.Image_URL).FirstOrDefault();
            return url;
        }

        private string GetTitle(string book_Id, IEnumerable<Book> bookList)
        {
            var title= (from b in bookList where b.Book_Id== book_Id select b.Book_Title).FirstOrDefault();
            return title;
        }

        public Task<Book> GetImportDetailById(string importDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateImportDetail(ImportationDetail importDetail)
        {
            throw new NotImplementedException();
        }

       
    }
}
