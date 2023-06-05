using BookStoreAPI.Core.Model;
using Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class RequestService : IRequestService
    {
        public Task<bool> CreateRequest(BookingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRequest(string requestId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingRequest>> GetAllRequest()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetRequestById(string requestId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRequest(BookingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
