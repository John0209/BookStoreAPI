using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.Model
{
    public class Importation
    {
        string Import_Id { get; set; }
        string Employee_Id { get; set; }
        DateTime Import_Date { get; set; }
        string Request_Id { get; set; }
        bool Is_Import_Status { get; set; }
    }
}
