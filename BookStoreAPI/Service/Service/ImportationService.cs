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
    public class ImportationService : IImportationService
    {
        IUnitOfWorkRepository _unit;
        IUserRepository _user;
        private Importation m_import;
        public ImportationService(IUnitOfWorkRepository unit, IUserRepository user)
        {
            _unit = unit;
            _user = user;
        }
        public async Task<bool> CreateImport(Importation import)
        {
            if (import != null)
            {
                var m_list = await GetAllImport();
                import.Import_Id = CreateId(m_list);
                await _unit.Importation.Add(import);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }
        private string CreateId(IEnumerable<Importation> m_list)
        {
            if (m_list.Count() <1)
            {
                var id = "IM1";
                return id;
            }
            var m_id = m_list.LastOrDefault().Import_Id;
            if (m_id != null)
            {
                var number = Int32.Parse(m_id.Substring(m_id.Length - 1));
                number++;
                var id = "IM" + number;
                return id;
            }
            return null;
        }

        public async Task<bool> DeleteImport(string importId)
        {
            var m_update = _unit.Importation.SingleOrDefault(m_import, u => u.Import_Id==importId);
            if (m_update != null)
            {
                m_update.Is_Import_Status = false;
                _unit.Importation.Update(m_update);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }
        public async Task<IEnumerable<Importation>> GetAllImport()
        {
            var result = await _unit.Importation.GetAll();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<DisplayImportationDTO>> GetDiplayImport()
        {
            var importList = await _unit.Importation.GetAll();
            var userList= await _unit.User.GetAll();
            var display = new List<DisplayImportationDTO>();
            foreach (var item in importList)
            {
                var import = new DisplayImportationDTO();
                import.Import_Quantity = item.Import_Quantity;
                import.Import_Amount=item.Import_Amount;
                import.Import_Date_Done = item.Import_Date_Done;
                import.Is_Import_Status= item.Is_Import_Status;
                import.User_Name = GetNameUser(item.User_Id, userList);
                display.Add(import);
            }
            if (display.Count < 1) return null;
            return display;
        }

        private string GetNameUser(string user_Id, IEnumerable<User> userList)
        {
            var userName = (from u in userList where u.User_Id == user_Id select u.User_Name).FirstOrDefault();
            return userName;
        }

        public Task<Book> GetImportById(string importId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateImport(Importation import)
        {
            var m_update = _unit.Importation.SingleOrDefault(m_import, u => u.Import_Id== import.Import_Id);
            if (import != null)
            {
                m_update.Import_Quantity= import.Import_Quantity;
                m_update.Import_Amount= import.Import_Amount;
                _unit.Importation.Update(m_update);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }

        
    }
}
