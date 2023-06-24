using BookStoreAPI.Core.DiplayDTO;
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
    public class OrderDetailService : IOrderDetailService
    {
        IUnitOfWorkRepository _unit;
        IBookService _book;
        private readonly OrderDetail m_order;
        public OrderDetailService(IUnitOfWorkRepository unit, IBookService book)
        {
            _unit = unit;
            _book = book;
        }
        public async Task<bool> CreateOrderDetail(OrderDetail order)
        {
            if (order != null)
            {
                var m_list = await GetAllOrderDetail();
                order.Order_Detail_Id = CreateId(m_list);
                await _unit.OrderDetail.Add(order);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }
        private string CreateId(IEnumerable<OrderDetail> m_list)
        {
            if (m_list.Count() < 1)
            {
                var id = "OD1";
                return id;
            }
            var m_id = m_list.LastOrDefault().Order_Detail_Id;
            if (m_id != null)
            {
                var number = Int32.Parse(m_id.Substring(m_id.Length - 1));
                number++;
                var id = "OD" + number;
                return id;
            }
            return null;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetail()
        {
            var result = await _unit.OrderDetail.GetAll();
            if (result != null)
            {
                return result;
            }
            return null;
        }
        public async Task<IEnumerable<DisplayOrderDetailDTO>> GetDisplayOrderDetail()
        {
            var orderList = await _unit.OrderDetail.GetAll();
            var bookList = await _unit.Books.GetAll();
            var image = await _unit.Images.GetAll();
            // get filed để display
            var display = new List<DisplayOrderDetailDTO>();
            foreach (var item in orderList)
            {
                var order = new DisplayOrderDetailDTO();
                order.Order_Detail_Quantity=order.Order_Detail_Quantity;
                order.Order_Detail_Price=order.Order_Detail_Price;
                order.Order_Detail_Amount=order.Order_Detail_Amount;
                order.Book_Title= GetTitle(item.Book_Id, bookList);
                order.Image_URL = GetUrl(item.Book_Id, image);
                display.Add(order);
            }
            if (display.Count < 1) return null;
            return display;

        }
        private string GetUrl(string book_Id, IEnumerable<ImageBook> image)
        {
            var url = (from b in image where b.Book_Id == book_Id select b.Image_URL).FirstOrDefault();
            return url;
        }

        private string GetTitle(string book_Id, IEnumerable<Book> bookList)
        {
            var title = (from b in bookList where b.Book_Id == book_Id select b.Book_Title).FirstOrDefault();
            return title;
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
