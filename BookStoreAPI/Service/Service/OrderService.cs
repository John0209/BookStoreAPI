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
    public class OrderService : IOrderService
    {
        IUnitOfWorkRepository _unit;
        IUserService _user;
        private readonly Order m_order;
        public OrderService(IUnitOfWorkRepository unit, IUserService user)
        {
            _unit = unit;
            _user = user;
        }
        public async Task<bool> CreateOrder(Order order)
        {
            if (order != null)
            {
                var m_list = await GetAllOrder();
                order.Order_Id = CreateId(m_list);
                await _unit.Order.Add(order);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }
        private string CreateId(IEnumerable<Order> m_list)
        {
            if (m_list.Count() < 1)
            {
                var id = "O1";
                return id;
            }
            var m_id = m_list.LastOrDefault().Order_Id;
            if (m_id != null)
            {
                var number = Int32.Parse(m_id.Substring(m_id.Length - 1));
                number++;
                var id = "O" + number;
                return id;
            }
            return null;
        }

        public async Task<bool> DeleteOrder(string orderId)
        {
            var m_update = _unit.Order.SingleOrDefault(m_order, u => u.Order_Id == orderId);
            if (m_update != null)
            {
                m_update.Is_Order_Status = false;
                _unit.Order.Update(m_update);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }

        public async Task<IEnumerable<Order>> GetAllOrder()
        {
            var result = await _unit.Order.GetAll();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public Task<Book> GetOrderById(string orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            var m_update = _unit.Order.SingleOrDefault(m_order, u => u.Order_Id==order.Order_Id);
            if (order!= null)
            {
                m_update.Order_Quantity = order.Order_Quantity;
                m_update.Order_Amount = order.Order_Amount;
                _unit.Order.Update(m_update);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }
    }
}
