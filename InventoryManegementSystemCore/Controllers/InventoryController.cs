using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InventoryManegementSystemCore.View;
using InventoryManegementSystemCore.BusinessLogic;

namespace InventoryManegementSystemCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : MyDBController<InventoryObject, InventoryRepository>
    {
        public InventoryController(InventoryRepository category) : base(category)
        {

        }
    }
}