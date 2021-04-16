using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypernovaLabsAPITest.Models
{
    public class CarModel
    {
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public int ModelYear { get; set; }
        public Brand Brand { get; set; }
        public Color Color { get; set; }
    }
}