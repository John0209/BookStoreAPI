﻿using BookStoreAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.IService
{
    public interface IInventoryService
    {
        Task<bool> CreateInventory(Inventory inventory);
        Task<IEnumerable<Inventory>> GetInventory();
        Task<Book> GetInventoryById(string inventoryId);
        Task<bool> UpdateInventory(Inventory inventory);
        Task<bool> DeleteInventory(string inventoryId);
    }
}
