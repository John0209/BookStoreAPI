using BookStoreAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.IService
{
    public interface IOrderDetailService
    {
        Task<bool> CreateOrderDetail(OrderDetail orderDetail);
        Task<IEnumerable<OrderDetail>> GetAllOrderDetail();
        Task<Book> GetOrderDetailById(string orderDetailId);
        Task<bool> UpdateOrderDetail(OrderDetail orderDetail);
    }
}
