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
    public class InventoryService : IInventoryService
    {
        IUnitOfWorkRepository _unit;
        //IUserService _user;
        //IBookService _book;
        //IImageService _image;
        public InventoryService(IUnitOfWorkRepository unit)
          //  , IUserService user, IBookService book, IImageService image)
        {
            _unit = unit;
            //_user = user;
            //_book = book;
            //_image = image;
        }

        public Task<bool> CreateInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteInventory(string inventoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InventoryDTO>> GetAllInventory()
        {
            var listInventory = await _unit.Inventory.GetAll();
            var listUser = await _unit.User.GetAll();
            var listImage = await _unit.Images.GetAll();
            var listBook= await _unit.Books.GetAll();
            //lấy thông tin để show ra screen
            var listDisplay = new List<InventoryDTO>();
            foreach(var i in listInventory)
            {
                var dto = new InventoryDTO();
                dto.Image_URL = GetURL(listImage, i.Book_Id);
                dto.Book_Title = GetTitle(listBook, i.Book_Id);
                dto.Inventory_Quantity = i.Inventory_Quantity;
                dto.Inventory_Note = i.Inventory_Note;
                dto.Inventory_Date_Into=i.Inventory_Date_Into;
                dto.User_Name = GetName(listUser, i.User_Id);
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
    }
}
