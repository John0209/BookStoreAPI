using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.Model
{
    public class Inventory
    {
        string Inventory_Id { get; set; }
        string Employee_Id { get;set; }
        DateTime Inventory_Date_Into { get; set; }
        bool Is_Inventory_Status { get; set; }
    }
}
