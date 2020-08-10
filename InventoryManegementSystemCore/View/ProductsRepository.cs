using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManegementSystemCore.BusinessLogic;
using InventoryManegementSystemCore.Data;
using InventoryManegementSystemCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManegementSystemCore.View
{
    // methods specific for Products Controller 
    public class ProductsRepository : EfCoreRepository<Product, Data.Furniture_InventoryContext> 
    {
        private readonly Data.Furniture_InventoryContext context;
        public ProductsRepository(Data.Furniture_InventoryContext context):base(context)
        {
            this.context = context;
        }


        public Task<List<Product>> GetAllProducts()
        {
           return context.Product.ToListAsync();

        }

        public List<ProductObject> GetProductList()
        {
            List<Product> listofp = context.Product.ToList();
            List<ProductObject> products = new List<ProductObject>();

            foreach (Product p in listofp)
            {
                ProductObject newprod = new ProductObject();
                newprod.ProductId = p.ProductId;
                newprod.ProductName = p.ProductName;
                newprod.ProductCode = p.ProductCode;
                newprod.ReleaseDate = p.ReleaseDate;
                newprod.Description = p.Description;
                newprod.Price = p.Price;
                newprod.StareRating = p.StareRating;
                newprod.ImgUrl = p.ImgUrl;
                newprod.idCategory = p.IdCatergory;
                newprod.Quantity = p.Quantity;
                newprod.Discount = p.Discount;
                newprod.SoldQuantity = p.SoldQuantity;
                if (p.IdCatergory != null && p.IdCatergory!=0)
                {
                    Category catergory = context.Category.Find(p.IdCatergory);
                    newprod.Catergory = catergory.CategoryName;
                }
                else newprod.Catergory = String.Empty;

                products.Add(newprod);
            }
            return products;
        }

        public async Task<List<ProductObject>> TaskGetProdList()
        {
           var result = await Task.Run(() => GetProductList());           
            return result;
        }


        public  void InsertAProduct(Product product)
        {
            context.Add(product);            
        }
        public async Task<Product> DeleteProduct(int id)
        {
            Product entity = await context.Product.FindAsync(id);
                //Set<Product>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<Product>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }


        public async Task<Product> UpdateProduct(int id,Product product)
        {
            var entity = await context.Set<Product>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            entity.ProductName = product.ProductName;
            entity.ProductCode = product.ProductCode;
            entity.ReleaseDate = product.ReleaseDate;
            entity.Description = product.Description;
            entity.Price = product.Price;
            entity.StareRating = product.StareRating;
            entity.ImgUrl = product.ImgUrl;
            entity.Discount = product.Discount;
            entity.IdCatergory = product.IdCatergory;
            entity.Quantity = product.Quantity;


            context.Set<Product>().Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }
        public List<String> GetAllProductsNames()
        {
            List<String> catname = new List<string>();
            foreach (var c in context.Product.ToList())
            {
                catname.Add(c.ProductName);
            }
            return catname;
        }

        public async Task<Decimal> CalculateDiscount(Product product)
        {
            decimal newprice = Decimal.Zero;
            try
            {
                var entity = await context.Set<Product>().FindAsync(product.ProductId);
                if (entity.Discount > 0)
                {
                    decimal totlprice = (decimal)entity.Price;
                    decimal discount = (decimal)entity.Discount;
                    newprice = totlprice - (totlprice * discount / 100);
                }
                else newprice = (decimal)entity.Price;
                
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return newprice;
        }
        
    }
}
