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
    public class ProductsController: Controller
    {
        private readonly ProductsRepository repository;
        public ProductsController(ProductsRepository category)
        {
            this.repository = category;
        }

        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return await repository.GetAllProducts();
        }

        public async Task<ActionResult<IEnumerable<ProductObject>>> GetListOfProducts()
        {
            return await repository.TaskGetProdList();
        }
        public async Task<ActionResult<Product>> Post(Product product)
        {
            await repository.Add(product);
            return CreatedAtAction("Get", product);
        }

        //Insert a new Product 
        public async Task<ActionResult<Product>> NewProduct(string ProductName, string ProductCode, string ReleaseDate, string Description,
                                                                               decimal? Price, decimal? StareRating, string ImgUrl, int quantity, decimal discount, int idCatergory)
        {
            Product product = new Product();
            try
            {

                product.ProductName = ProductName;
                product.ProductCode = ProductCode;
                product.ReleaseDate = ReleaseDate;
                product.Description = Description;
                product.Price = Price;
                product.StareRating = StareRating;
                product.ImgUrl = ImgUrl;
                product.Quantity= quantity;
                product.Discount = discount;
                product.IdCatergory = idCatergory;

                await repository.Add(product);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return CreatedAtAction("Get", product);
        }

        //Delete a Product 


        public async Task<ActionResult<Product>> DeleteProduct(int ProductId)
        {
            var entity = new Product();
            try
            {

                entity = await repository.DeleteProduct(ProductId);
                if (entity == null)
                {
                    return NotFound(ProductId);
                }
            }

            catch (Exception exc)
            {
                throw exc;
            }
            return (entity);
        }

        //Update a Product
        public async Task<ActionResult<Product>> UpdateProduct(int ProductId, string ProductName, string ProductCode, string ReleaseDate, string Description,
                                                                               decimal? Price, decimal? StareRating, string ImgUrl, int quantity, decimal? discount, int idCatergory)
        {
            var entity = new Product();
            Product product = new Product();
            try
            {
                product.ProductName = ProductName;
                product.ProductCode = ProductCode;
                product.ReleaseDate = ReleaseDate;
                product.Description = Description;
                product.Price = Price;
                product.StareRating = StareRating;
                product.ImgUrl = ImgUrl;
                product.Quantity = quantity;
                product.Discount = discount;
                product.IdCatergory = idCatergory;

                entity = await repository.UpdateProduct(ProductId, product);
                if (entity == null)
                {
                    return NotFound();
                }
            }

            catch (Exception exc)
            {
                throw exc;
            }
            return entity;
        }



        // get product discount
        public async Task<ActionResult<Decimal>> CalculateDiscount(Product product)
        {
            return await this.repository.CalculateDiscount(product);
        }

        public List<String> GetAllProductName()
        {
            return this.repository.GetAllProductsNames();
        }

    }


}
