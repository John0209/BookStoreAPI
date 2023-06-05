using BookStoreAPI.Core.Model;
using Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        public Task<bool> CreateOrderDetail(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetail>> GetAllOrderDetail()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetOrderDetailById(string orderDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderDetail(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
