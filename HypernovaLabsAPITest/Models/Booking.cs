using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HypernovaLabsAPITest.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }
        [Required]
        public DateTime BookingDateFrom { get; set; }
        [Required]
        public DateTime BookingDateTo { get; set; }
        [Required]
        public int TotalDays { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string Email { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Required]
        [ForeignKey("CarModel")]
        public int ModelID { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public CarModel CarModel { get; set; }
        public User? User { get; set; }
    }
}