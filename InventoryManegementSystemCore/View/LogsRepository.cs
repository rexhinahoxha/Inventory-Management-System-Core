using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManegementSystemCore.View;
using InventoryManegementSystemCore.Model;
using InventoryManegementSystemCore.Data;

namespace InventoryManegementSystemCore.View
{
    public class LogsRepository : EfCoreRepository<Logs, Data.Furniture_InventoryContext>
    {
        public LogsRepository(Data.Furniture_InventoryContext context) : base(context)
        {

        }    
    }
}
