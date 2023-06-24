﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.DTO
{
    public class ImportationDTO
    {
        public string Import_Id { get; set; }
        public string User_Id { get; set; }
        public int Import_Quantity { get; set; }
        public float Import_Amount { get; set; }
        public DateTime Import_Date_Done { get; set; }
        public bool Is_Import_Status { get; set; }

    }
}
