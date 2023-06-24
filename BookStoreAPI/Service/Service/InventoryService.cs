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
    public class InventoryService : IInventoryService
    {
        IUnitOfWorkRepository _unit;
        //IUserService _user;
        //IBookService _book;
        //IImageService _image;
        private Inventory m_inventory;
        public InventoryService(IUnitOfWorkRepository unit)
          //  , IUserService user, IBookService book, IImageService image)
        {
            _unit = unit;
            //_user = user;
            //_book = book;
            //_image = image;
        }

        public async Task<bool> CreateInventory(Inventory inventory)
        {
            if (inventory != null)
            {
                var m_list= await GetInventory();
                inventory.Inventory_Id = CreateInventoryId(m_list);
                await _unit.Inventory.Add(inventory);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }

        private string CreateInventoryId(IEnumerable<Inventory> m_list)
        {
            if (m_list.Count() < 1)
            {
                var id = "I1";
                return id;
            }
            var m_id = m_list.LastOrDefault().Inventory_Id;
            if(m_id!=null)
            {
                var number=Int32.Parse(m_id.Substring(m_id.Length-1));
                number++;
                var InventoryId = "I" + number;
                return InventoryId;
            }
            return null;
        }

        public async Task<bool> DeleteInventory(string inventoryId)
        {
            var m_update = _unit.Inventory.SingleOrDefault(m_inventory, u => u.Inventory_Id==inventoryId);
            if (m_update != null)
            {
                m_update.Is_Inventory_Status = false;
                _unit.Inventory.Update(m_update);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }

        public async Task<IEnumerable<DisplayInventoryDTO>> GetAllInventory()
        {
            var listInventory = await _unit.Inventory.GetAll();
            var listUser = await _unit.User.GetAll();
            var listImage = await _unit.Images.GetAll();
            var listBook= await _unit.Books.GetAll();
            //lấy thông tin để show ra screen
            var listDisplay = new List<DisplayInventoryDTO>();
            foreach(var i in listInventory)
            {
                var dto = new DisplayInventoryDTO();
                dto.Inventory_Id = i.Inventory_Id;
                dto.Image_URL = GetURL(listImage, i.Book_Id);
                dto.Book_Title = GetTitle(listBook, i.Book_Id);
                dto.Inventory_Quantity = i.Inventory_Quantity;
                dto.Inventory_Note = i.Inventory_Note;
                dto.Inventory_Date_Into=i.Inventory_Date_Into;
                dto.User_Name = GetName(listUser, i.User_Id);
                dto.Is_Inventory_Status= i.Is_Inventory_Status;
                listDisplay.Add(dto);
            }
            if(listDisplay.Count()>0) return listDisplay;
            return null;
        }

        private string GetName(IEnumerable<User> listUser, string user_Id)
        {
            var name = (from i in listUser where i.User_Id == user_Id select i.User_Name).FirstOrDefault();
            return name;
        }

        private string GetTitle(IEnumerable<Book> listBook, string book_Id)
        {
            var title = (from i in listBook where i.Book_Id == book_Id select i.Book_Title).FirstOrDefault();
            return title;
        }

        private string GetURL(IEnumerable<ImageBook> listImage, string book_Id)
        {
            var url= (from i in listImage where i.Book_Id==book_Id select i.Image_URL).FirstOrDefault();
            return url;
        }

        public Task<Book> GetInventoryById(string inventoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Inventory>> GetInventory()
        {
            var result = await _unit.Inventory.GetAll();
            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}
