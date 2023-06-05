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
        public Task<bool> CreateInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteInventory(string inventoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Inventory>> GetAllInventory()
        {
            throw new NotImplementedException();
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
