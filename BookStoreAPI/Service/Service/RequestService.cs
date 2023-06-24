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
    public class RequestService : IRequestService
    {
        IUnitOfWorkRepository _unit;
        public RequestService(IUnitOfWorkRepository unit)
        { 
            _unit = unit;
        }

        public async Task<bool> CreateRequest(BookingRequest request)
        {
            if (request != null)
            {
                var m_list = await GetAllRequest();
                request.Request_Id = CreateId(m_list);
                await _unit.Request.Add(request);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }
        private string CreateId(IEnumerable<BookingRequest> m_list)
        {
            if (m_list.Count() < 1)
            {
                var id = "R1";
                return id;
            }
            var m_id = m_list.LastOrDefault().Request_Id;
            if (m_id != null)
            {
                var number = Int32.Parse(m_id.Substring(m_id.Length - 1));
                number++;
                var id = "R" + number;
                return id;
            }
            return null;
        }

        public Task<bool> DeleteRequest(string requestId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookingRequest>> GetAllRequest()
        {
            var result = await _unit.Request.GetAll();
            if (result != null)
            {
                return result;
            }
            return null;
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
