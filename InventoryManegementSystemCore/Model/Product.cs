using System;
using System.Collections.Generic;

namespace InventoryManegementSystemCore.Model
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ReleaseDate { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? StareRating { get; set; }
        public string ImgUrl { get; set; }
        public int? Quantity { get; set; }
        public decimal? Discount { get; set; }
        public int? SoldQuantity { get; set; }
        public int? IdCatergory { get; set; }
        public long? IdSales { get; set; }

        public Sales IdSalesNavigation { get; set; }
    }
}
