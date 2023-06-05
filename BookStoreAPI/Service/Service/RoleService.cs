using BookStoreAPI.Core.Model;
using Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class RoleService : IRoleService
    {
        public Task<bool> CreateRole(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRole(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetAllRole()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetRoleById(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRole(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
