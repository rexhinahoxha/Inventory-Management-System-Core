using System;
using System.Collections.Generic;

namespace InventoryManegementSystemCore.Model
{
    public partial class Sales
    {
        public Sales()
        {
            Product = new HashSet<Product>();
        }

        public long IdSales { get; set; }
        public int? IdUser { get; set; }
        public DateTime? DateOfSale { get; set; }
        public string ProductList { get; set; }
        public decimal? Total { get; set; }

        public Users IdUserNavigation { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
