﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Core.DTO
{
   public class InventoryDTO
    {
        public string Inventory_Id { get; set; }
        public string User_Id { get; set; }
        public string Book_Id { get; set; }
        public int Inventory_Quantity { get; set; }
        public string Inventory_Note { get; set; }
        public DateTime Inventory_Date_Into { get; set; }
        public bool Is_Inventory_Status { get; set; }
    }
}