using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InventoryManegementSystemCore.Model;
using InventoryManegementSystemCore.View;


namespace InventoryManegementSystemCore.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoriesRepository repository;
        public CategoriesController(CategoriesRepository category)
        {
            this.repository = category;
        }

        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            return await repository.GetAllCategories();
        }

        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            return await repository.GetbyId(id);
        }
    }
}
