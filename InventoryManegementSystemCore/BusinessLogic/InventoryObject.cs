using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManegementSystemCore.BusinessLogic
{
    public class InventoryObject
    {       
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int? quantity { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public string status { get; set; }
    }
}
