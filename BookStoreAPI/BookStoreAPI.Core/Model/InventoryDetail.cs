using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.Model
{
    public class InventoryDetail
    {
        public string Inventory_Detail_Id { get; set; }
        public string Inventory_Id { get; set; }
        public string Book_Id { get; set; }
        public int Inventory_Detail_Quantity { get; set; }
        public string Inventory_Detail_Note { get; set; }
        public Book Book { get; set; }
        public Inventory Inventory { get; set; }

    }
}
