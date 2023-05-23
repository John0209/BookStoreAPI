using BookStoreAPI.Core.Model;
using BookStoreAPI.Infracstructure.Helper;
using Microsoft.EntityFrameworkCore;
using Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class AdminService:IAdminService
    {
        DbContextClass _dbContext;
        public AdminService(DbContextClass dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Admin>> GetAll()
        {
            var result =await _dbContext.Set<Admin>().ToListAsync();
            if(result.Count > 0)
            {
                return result;
            }
            return null;
        }
    }
}
