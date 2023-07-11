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
                //var m_list = await GetAllOrder();
                order.Order_Id = Guid.NewGuid();
                order.Is_Order_Status = 1;
                await _unit.Order.Add(order);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }

        public async Task<bool> DeleteOrder(Guid orderId)
        {
            var m_update = _unit.Order.SingleOrDefault(m_order, u => u.Order_Id == orderId);
            if (m_update != null)
            {
                m_update.Is_Order_Status = 0;
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

        public async Task<bool> RestoreOrder(Guid orderId)
        {
            var m_update = _unit.Order.SingleOrDefault(m_order, u => u.Order_Id == orderId);
            if (m_update != null)
            {
                m_update.Is_Order_Status = 2;
                _unit.Order.Update(m_update);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }

        public async Task<IEnumerable<Order>> GetOrderByUserId(Guid userId)
        {
            var listOrder = await GetAllOrder();
            var order = from b in listOrder where b.User_Id == userId select b;
            if (order != null)
            return order;
            return null;
        }

        public async Task<bool> RemoveOrder(Guid orderId)
        {
            var import = await _unit.Order.GetById(orderId);
            var importDetailList = await _unit.OrderDetail.GetAll();
            var listDetail = from i in importDetailList where i.Order_Id == orderId select i;
            if (import != null)
            {
                if (listDetail.Count() > 0)
                {
                    foreach (var i in listDetail)
                    {
                        _unit.OrderDetail.Delete(i);
                        _unit.Save();
                    }
                }
                _unit.Order.Delete(import);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }
    }
}
