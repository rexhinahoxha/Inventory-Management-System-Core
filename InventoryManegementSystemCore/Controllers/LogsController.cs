using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InventoryManegementSystemCore.View;
using InventoryManegementSystemCore.Model;

namespace InventoryManegementSystemCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : MyDBController<Logs, LogsRepository>
    {
        public LogsController(LogsRepository category) : base(category)
        {

        }
    }
}