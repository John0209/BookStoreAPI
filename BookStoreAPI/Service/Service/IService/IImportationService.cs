using BookStoreAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.IService
{
   public interface IImportationService
    {
        Task<bool> CreateImport(Importation import);
        Task<IEnumerable<Importation>> GetImport();
        Task<Book> GetImportById(string importId);
        Task<bool> UpdateImport(Importation import);
        Task<bool> DeleteImport(string importId);
    }
}
