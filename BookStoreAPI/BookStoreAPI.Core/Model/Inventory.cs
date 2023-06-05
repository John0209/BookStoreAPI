using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.Model
{
    public class Inventory
    {
        public string Inventory_Id { get; set; }
        public string User_Id { get; set; }
        public DateTime Inventory_Date_Into { get; set; }
        public bool Is_Inventory_Status { get; set; }
        public User User { get; set; }
        public ICollection<InventoryDetail> InventoryDetails { get; set; }
    }
}
