using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using InventoryManegementSystemCore.Data;
using InventoryManegementSystemCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManegementSystemCore.View
{
    public class SalesRepository : EfCoreRepository<Sales, Data.Furniture_InventoryContext>
    {

        private readonly Data.Furniture_InventoryContext context;
        public SalesRepository(Data.Furniture_InventoryContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Decimal> InsertSale( List<Product> salesList, int idUser)
        {
            Decimal total = Decimal.Zero;

            Sales sale = new Sales();

            try
            {

            sale.IdUser = idUser;
            sale.DateOfSale= DateTime.Now;

            foreach( Product p in salesList)
            {
                decimal discountprice= (decimal)(p.Price - (p.Price * p.Discount / 100));
                sale.ProductList=p.ProductName+" ";
                if (discountprice > 0) total = total + discountprice;
                else total = (decimal)(total + p.Price);
            }

               await  context.Sales.AddAsync(sale);
            }

            catch (Exception Ex)
            {
                throw Ex;
            }

            return total;
        }
              

        public DataTable Report(int idUser)
        {
            DataTable tbl = new DataTable();

            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText =String.Format("SELECT IdSales,[DateOfSale],[ProductList],[Total],[dbo].[Users].UserName as 'User Who Sold'" +
                                    " FROM [Sales] inner join [Users] on [Users].IDUser " +
                                    "=[Sales].idUser  where  [Users].IDUser={0}", idUser);
                context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    tbl.Load(result);
                }
            }         
            

            return tbl;
        }
        public DataTable Report()
        {
            DataTable tbl = new DataTable();

            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = String.Format("SELECT IdSales,convert(varchar, DateOfSale, 7) as DateOfSale ,[ProductList],[Total],[dbo].[Users].UserName as 'UserWhoSold'" +
                                    " FROM [Sales] inner join [Users] on [Users].IDUser " +
                                    "=[Sales].idUser");
                context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    tbl.Load(result);
                }
            }            
            return tbl;
        }


        public Task<List<Sales>> GetAllSales()
        {
            return context.Sales.ToListAsync();

        }

    }
}
