using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.DTO
{
    public class OrderDTO
    {
        public string Order_Id { get; set; }
        public string User_Id { get; set; }
        public string Order_Customer_Name { get; set; }
        public string Order_Customer_Address { get; set; }
        public string Order_Customer_Phone { get; set; }
        public DateTime Order_Date { get; set; }
        public int Order_Quantity { get; set; }
        public float Order_Amount { get; set; }
        public bool Is_Order_Status { get; set; }
    }
}
