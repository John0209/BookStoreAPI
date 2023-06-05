using BookStoreAPI.Core.Model;
using Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class InventoryDetailService : IInventoryDetailService
    {
        public Task<bool> CreateInventoryDetail(InventoryDetail inventoryDetail)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InventoryDetail>> GetAllInventoryDetail()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetInventoryDetailById(string inventoryDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateInventoryDetail(InventoryDetail inventoryDetail)
        {
            throw new NotImplementedException();
        }
    }
}
