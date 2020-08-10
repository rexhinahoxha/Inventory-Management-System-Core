using System;
using System.Collections.Generic;

namespace InventoryManegementSystemCore.Model
{
    public partial class Users
    {
        public Users()
        {
            Sales = new HashSet<Sales>();
        }

        public int Iduser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<Sales> Sales { get; set; }
    }
}
