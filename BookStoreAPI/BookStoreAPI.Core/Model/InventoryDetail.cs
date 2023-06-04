using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.Model
{
    public class InventoryDetail
    {
        string Inventory_Detail_Id { get; set; }
        string Inventory_Id { get; set; }
        string Book_Id { get; set; }
        int Inventory_Quantity { get; set; }
        string Inventory_Note { get; set; }
       
    }
}
