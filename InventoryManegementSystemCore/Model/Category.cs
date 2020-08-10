using System;
using System.Collections.Generic;

namespace InventoryManegementSystemCore.Model
{
    public partial class Category
    {
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
        public bool? IsActive { get; set; }
    }
}
