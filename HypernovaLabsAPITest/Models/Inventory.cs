using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HypernovaLabsAPITest.Models
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryID { get; set; }
        [Required]
        [ForeignKey("CarModel")]
        public int ModelID { get; set; }
        public CarModel CarModel { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public decimal DayPrice { get; set; }
    }
}