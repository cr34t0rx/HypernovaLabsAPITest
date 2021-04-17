using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HypernovaLabsAPITest.Models
{
    public class CarModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModelID { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public int ModelYear { get; set; }
        [Required]
        [ForeignKey("Brand")]
        public int BrandID { get; set; }
        [Required]
        [ForeignKey("Color")]
        public int ColorID { get; set; }
        public Color Color { get; set; }
        public Brand Brand { get; set; }
        [Required]
        public int Inventory { get; set; }
        [Required]
        public decimal DayPrice { get; set; }
    }
}