using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.Model
{
    public class ImportationDetail
    {
        string Import_Detail_Id { get; set; }
        string Import_Id { get; set; }
        string Book_Id { get; set; }
        int Import_Quantity { get; set; }
        float Import_Price { get; set; }
        float Import_Amount { get; set; }
        string Import_Note { get; set; }
       
    }
}
