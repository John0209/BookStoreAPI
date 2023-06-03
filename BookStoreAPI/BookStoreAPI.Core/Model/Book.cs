using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.Model
{
    public class Book
    {
        string Book_Id { get; set; }
        int Image_Id { get; set; }
        string Book_Title { get; set; }
        string Book_Author { get; set; }
        float Book_Price { get; set; }
        int Book_ISBN { get; set; }
        bool Is_Book_Status { get; set; }
    }
}
