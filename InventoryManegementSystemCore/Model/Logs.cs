using System;
using System.Collections.Generic;

namespace InventoryManegementSystemCore.Model
{
    public partial class Logs
    {
        public long LogId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
