using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.Model
{
    public class Category
    {
        public string Category_Id { get; set; }
        public string Category_Name { get; set; }
        public bool Is_Category_Status { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
