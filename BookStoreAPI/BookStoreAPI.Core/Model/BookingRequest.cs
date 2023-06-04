using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.Model
{
    public class BookingRequest
    {
        string Request_Id { get; set; }
        string Request_Image_Url { get; set; }
        string Request_Book_Name { get; set; }
        int Request_Quantity { get; set; }
        float Request_Price { get; set; }
        DateTime Request_Date { get; set; }
        DateTime Request_Date_Done { get; set; }
        string Request_Note { get; set; }
        bool Is_Request_Status { get; set; }
    }
}
