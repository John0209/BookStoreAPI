using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.Model
{
    public class BookingRequest
    {
        public string Request_Id { get; set; }
        public string Book_Id { get; set; }
        public string Import_Id { get; set; }
        public string Request_Image_Url { get; set; }
        public string Request_Book_Name { get; set; }
        public int Request_Quantity { get; set; }
        public float Request_Price { get; set; }
        public float Request_Amount { get; set; }
        public DateTime Request_Date { get; set; }
        public DateTime Request_Date_Done { get; set; }
        public string Request_Note { get; set; }
        public int Is_Request_Status { get; set; }
        public Importation Importation { get; set; }
        public Book Book { get; set; }
    }
}
