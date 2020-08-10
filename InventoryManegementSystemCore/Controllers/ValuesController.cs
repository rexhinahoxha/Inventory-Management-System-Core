using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InventoryManegementSystemCore.Data;
using Newtonsoft.Json;
using InventoryManegementSystemCore.BusinessLogic;
using InventoryManegementSystemCore.Model;


namespace InventoryManegementSystemCore.Controllers
{

    public class ValuesController : Controller 
    {
        private readonly Data.Furniture_InventoryContext _context;

        public ValuesController(Data.Furniture_InventoryContext _context)
        {
            this._context = _context;
        }

        public Product[] GetTest()
        {
            Product[] productarray = new Product[2];

            Product prod = new Product();
            prod.ProductId = 2;
            prod.ProductName = "Garden Cart";
            prod.ProductCode = "GDN-0023";
            prod.ReleaseDate = "March 18, 2019";
            prod.Description = "15 gallon capacity rolling garden cart";
            prod.Price = (decimal)32.99;
            prod.StareRating = (decimal)4.2;
            prod.ImgUrl = "assets/images/garden_cart.png";
            Product pro = new Product();
            pro.ProductId = 2;
            pro.ProductName = "Garden Cart";
            pro.ProductCode = "GDN-0023";
            pro.ReleaseDate = "March 18, 2019";
            pro.Description = "15 gallon capacity rolling garden cart";
            pro.Price = (decimal)32.99;
            pro.StareRating = (decimal)4.2;
            pro.ImgUrl = "assets/images/garden_cart.png";

            productarray[0] = prod;
            productarray[1] = pro;

            return productarray;
        }

        public List<Product> GetAllProducts()
        {            
                return _context.Product.ToList();           

        }

        #region oldcode
        //public string GetLocations()
        //{
        //   List<LocationObject> locations = new List<LocationObject>();

        //    List<MenuLocation> menus = _context.MenuLocation.ToList();           

        //    foreach(var m in menus)
        //    {
        //        LocationObject loc = new LocationObject();

        //        loc.id = m.IdLocations;
        //        loc.name = m.MenuName;
        //        List<InventoryObject> inv = new List<InventoryObject>();

        //        InventoryObject inobj = new InventoryObject();
        //       IAsyncEnumerable<Inventory> invtlist = _context.Inventory.FindAsync(m.IdLocations).ToAsyncEnumerable();

        //        var invt = invtlist.ToList();
        //        if (invt.Result[0] != null)
        //        {
        //            foreach (Inventory i in invt.Result.ToList())
        //            {
        //                inobj.id = i.IdItem;
        //                inobj.name = i.ItemName;
        //                inobj.quantity = i.Quantity;
        //                inobj.status = i.Status;
        //                inobj.description = i.Description;

        //                IAsyncEnumerable<Category> catlist = _context.Category.FindAsync(m.IdLocations).ToAsyncEnumerable();
        //                var img = catlist.ToList();
        //                List<Category> ct = img.Result.ToList();
        //                inobj.category = ct.ElementAt(0).CategoryName;
        //                inobj.image = ct.ElementAt(0).ImageUrl;

        //                inv.Add(inobj);
        //            }
        //        }
        //        loc.Inventory = inv;
        //        locations.Add(loc);
        //    }
        //    return JsonConvert.SerializeObject(locations);


        //}

        //public string GetItems(long idLocation)
        //{
        //    List<InventoryObject> inv = new List<InventoryObject>();            

        //        InventoryObject inobj = new InventoryObject();
        //        IAsyncEnumerable<Inventory> invtlist = _context.Inventory.FindAsync(idLocation).ToAsyncEnumerable();

        //        var invt = invtlist.ToList();
        //        if (invt.Result[0] != null)
        //        {
        //            foreach (Inventory i in invt.Result.ToList())
        //            {
        //                inobj.id = i.IdItem;
        //                inobj.name = i.ItemName;
        //                inobj.quantity = i.Quantity;
        //                inobj.status = i.Status;
        //                inobj.description = i.Description;

        //                IAsyncEnumerable<Category> catlist = _context.Category.FindAsync(i.IdCategory).ToAsyncEnumerable();
        //                var img = catlist.ToList();
        //                List<Category> ct = img.Result.ToList();
        //                inobj.category = ct.ElementAt(0).CategoryName;
        //                inobj.image = ct.ElementAt(0).ImageUrl;

        //                inv.Add(inobj);
        //            }
        //        }                            

        //    return JsonConvert.SerializeObject(inv);

        //}
        #endregion
    }
}
 