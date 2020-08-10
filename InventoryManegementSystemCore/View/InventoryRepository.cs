using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManegementSystemCore.Model;
using InventoryManegementSystemCore.Data;
using InventoryManegementSystemCore.BusinessLogic;

namespace InventoryManegementSystemCore.View
{
    public class InventoryRepository : EfCoreRepository<InventoryObject, Data.Furniture_InventoryContext>
    {
        public InventoryRepository(Data.Furniture_InventoryContext context) : base(context)
        {

        }
    
    }
}
