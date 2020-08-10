using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManegementSystemCore.BusinessLogic
{
    public class LocationObject
    {
        public long id { get; set; }
        public string name { get; set; }
        public List<InventoryObject> Inventory { get; set; }
    }
}
