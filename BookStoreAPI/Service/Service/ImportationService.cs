using BookStoreAPI.Core.Model;
using Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ImportationService : IImportationService
    {
        public Task<bool> CreateImport(Importation import)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteImport(string importId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Importation>> GetAllImport()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetImportById(string importId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateImport(Importation import)
        {
            throw new NotImplementedException();
        }
    }
}
