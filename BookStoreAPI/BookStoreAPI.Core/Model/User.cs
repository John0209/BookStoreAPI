using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.Model
{
    public class User
    {
        string User_Id { get; set; }
        int Role_Id { get; set; }
        string User_Name { get; set; }
        string User_Email { get; set; }
        string User_Address { get; set; }
        string User_Phone { get; set; }
        bool Is_User_Gender { get; set; }
        bool Is_User_Status { get; set; }
    }
}
