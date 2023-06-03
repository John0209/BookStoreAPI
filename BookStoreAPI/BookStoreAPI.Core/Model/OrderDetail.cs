using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.Model
{
    public class OrderDetail
    {
        string Order_Detail_Id { get; set; }
        string Order_Id { get; set; }
        string Book_Id { get; set; }
        int Order_Quantity { get; set; }
        float Order_Amount { get; set; }
    }
}
