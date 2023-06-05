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
        public Task<bool> CreateImportDetail(ImportationDetail importDetail)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ImportationDetail>> GetAllImportDetail()
        {
            throw new NotImplementedException();
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
