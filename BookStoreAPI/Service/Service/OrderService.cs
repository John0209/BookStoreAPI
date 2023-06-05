using BookStoreAPI.Core.Model;
using Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class OrderService : IOrderService
    {
        public Task<bool> CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrder(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrder()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetOrderById(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
