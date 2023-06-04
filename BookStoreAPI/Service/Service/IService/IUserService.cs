using BookStoreAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.IService
{
    public interface IUserService
    {
        Task<bool> CreateUser(User user);
        Task<IEnumerable<User>> GetAllUser();
        Task<Book> GetUserById(string userId);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(string userId);
    }
}
