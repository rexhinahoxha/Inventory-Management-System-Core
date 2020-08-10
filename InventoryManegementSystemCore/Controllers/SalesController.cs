using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InventoryManegementSystemCore.Model;
using InventoryManegementSystemCore.View;
using InventoryManegementSystemCore.BusinessLogic;
using System.Data;

namespace InventoryManegementSystemCore.Controllers
{
    public class SalesController : Controller
    {
        private readonly SalesRepository repository;
        private readonly ProductsRepository repoProd;
        public SalesController(SalesRepository category, ProductsRepository repoProd)
        {
            this.repository = category;
            this.repoProd = repoProd;
        }


        public async Task<ActionResult<Decimal>> InsertNewSale(List<Product>listofproducts, int idUser)
        {           
             return await repository.InsertSale(listofproducts, idUser);       
        }
                      

        public async Task<ActionResult<Decimal>> AddSale(int prod1, int prod2, int prod3, int idUser)
        {
            Decimal total = Decimal.Zero;
            Sales sale = new Sales();

            HashSet<long> listofproducts = new HashSet<long>();
            listofproducts.Add(prod1);
            listofproducts.Add(prod2);
            listofproducts.Add(prod3);

            try
            {

                sale.IdUser = idUser;
                sale.DateOfSale = DateTime.Now;
                await repository.Add(sale);             

                foreach (int i in listofproducts)
                {
                    Product prod = repoProd.GetEntitybyId(i);
                    decimal discountprice = (decimal)(prod.Price - (prod.Price * prod.Discount / 100));
                    sale.ProductList = prod.ProductName + " ";
                    if (discountprice > 0) total = total + discountprice;
                    else total = (decimal)(total + prod.Price);
                    prod.IdSales = sale.IdSales;
                    prod.Quantity = prod.Quantity - 1;
                    prod.SoldQuantity = prod.SoldQuantity + 1;
                    await repoProd.Update(prod);
                }
                sale.Total = total;
                sale= await repository.Update(sale);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }

            return total;
        }
        public async Task<ActionResult<Sales>> InsertNewSaleObject()
        {
            Sales sale = new Sales();
            sale.DateOfSale = DateTime.Now;
             sale.IdUser = 1;
            sale.ProductList = "Test1, test2";
            sale.Total = 300;

            return await repository.Add(sale);
        }


      public DataTable Report(int idUser)
        {
            return repository.Report(idUser);
        }

        public DataTable Reports()
        {
            return repository.Report();
        }

        public async Task<ActionResult<IEnumerable<Sales>>> GetAllSales()
        {
            return await repository.GetAllSales();
        }

       
    }
}
