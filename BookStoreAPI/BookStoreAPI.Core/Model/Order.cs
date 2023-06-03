using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.Model
{
    public class Order
    {
        string Order_Id { get; set; }
        string User_Id { get; set; }
        DateTime Order_Date { get; set; }
        int Order_Quantity { get; set; }
        float Order_Amount { get; set; }
        string Order_Customer_Name { get; set; }
        string Order_Customer_Address { get; set; }
        string Order_Customer_Phone { get; set; }
        bool Is_Order_Status { get; set; }
    }
}
