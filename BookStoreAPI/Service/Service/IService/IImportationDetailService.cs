using BookStoreAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.IService
{
    public interface IImportationDetailService
    {
        Task<bool> CreateImportDetail(ImportationDetail importDetail);
        Task<IEnumerable<ImportationDetail>> GetAllImportDetail();
        Task<Book> GetImportDetailById(string importDetailId);
        Task<bool> UpdateImportDetail(ImportationDetail importDetail);
        //Task<bool> DeleteImportDetail(string importDetailId);
    }
}
