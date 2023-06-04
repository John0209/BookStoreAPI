using BookStoreAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.IService
{
    public interface IRequestService
    {
        Task<bool> CreateRequest(BookingRequest request);
        Task<IEnumerable<BookingRequest>> GetAllRequest();
        Task<Book> GetRequestById(string requestId);
        Task<bool> UpdateRequest(BookingRequest request);
        Task<bool> DeleteRequest(string requestId);
    }
}
