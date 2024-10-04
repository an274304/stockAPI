using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.V1.DTOs
{
    public class showAvailableStockTable
    {
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public int Total { get; set; }
        public int TotalAvailable { get; set; }
        public int TotalAssigned { get; set; }
        public int TotalDispose { get; set; }
    }
}
