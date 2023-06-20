using BookStoreAPI.Core.DTO;
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
    public class UserService : IUserService
    {
        IUnitOfWorkRepository _unit;
        public UserService(IUnitOfWorkRepository unit)
        {
            _unit=unit;
        }

        public async Task<User> CheckLogin(LoginDTO login)
        {
            var user = await _unit.User.GetAll();
            if (user != null)
            {
                var result = user.SingleOrDefault(u => u.User_Account == login.User_Account && u.User_Password == login.User_Password);
                if (result != null) return result;
                else return null;
            }
            return null;
        }

        public async Task<bool> CreateUser(User user)
        {
            if (user != null)
            {
                await _unit.User.Add(user);
                var result=_unit.Save();
                if(result >0)return true;
            }
            return false;
        }

        public Task<bool> DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            var result= await _unit.User.GetAll();
            if(result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<User> GetUserById(string userId)
        {
           var result=await _unit.User.GetById(userId);
            if (result != null) return result;
            return null;
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
