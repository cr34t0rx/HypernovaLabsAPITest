using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypernovaLabsAPITest.ViewModels
{
    public class InventoryViewModel
    {
        public int ModelID { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public int Inventory { get; set; }
        public decimal DayPrice { get; set; }
    }
}