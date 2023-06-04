using BookStoreAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.IService
{
    public interface IInventoryDetailService
    {
        Task<bool> CreateInventoryDetail(InventoryDetail inventoryDetail);
        Task<IEnumerable<InventoryDetail>> GetInventoryDetail();
        Task<Book> GetInventoryDetailById(string inventoryDetailId);
        Task<bool> UpdateInventoryDetail(InventoryDetail inventoryDetail);
    }
}
