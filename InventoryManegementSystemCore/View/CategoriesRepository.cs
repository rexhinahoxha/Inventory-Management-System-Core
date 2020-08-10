using InventoryManegementSystemCore.Data;
using InventoryManegementSystemCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManegementSystemCore.View
{
    public class CategoriesRepository : EfCoreRepository<Category, Data.Furniture_InventoryContext>
    {

        private readonly Data.Furniture_InventoryContext context;
        public CategoriesRepository(Data.Furniture_InventoryContext context) : base(context)
        {
            this.context = context;
        }

        public Task<List<Category>> GetAllCategories()
        {
            return context.Category.ToListAsync();

        }

    }
}
