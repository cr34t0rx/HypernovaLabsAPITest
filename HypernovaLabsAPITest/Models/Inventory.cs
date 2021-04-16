using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypernovaLabsAPITest.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public CarModel CarModel { get; set; }
        public int Availability { get; set; }
        public int Total { get; set; }
        public decimal DayPrice { get; set; }
    }
}