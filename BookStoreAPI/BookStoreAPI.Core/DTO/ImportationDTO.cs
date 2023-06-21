using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.DTO
{
    public class ImportationDTO
    {
        public string Image_Url { get; set; }
        public string Book_Title { get; set; }
        public int Import_Detail_Quantity { get; set; }
        public float Import_Detail_Price { get; set; }
        public float Import_Detail_Amount { get; set; }

    }
}
