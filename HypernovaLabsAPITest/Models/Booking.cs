using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypernovaLabsAPITest.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateTime BookingDateFrom { get; set; }
        public DateTime BookingDateTo { get; set; }
        public int TotalDays { get; set; }
        public int TotalPrice { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string Email { get; set; }
        public User? User { get; set; }
        public CarModel CarModel { get; set; }
        public DateTime CreationDate { get; set; }
    }
}