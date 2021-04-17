using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypernovaLabsAPITest.ViewModels
{
    public class CreateBookingViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int ModelID { get; set; }
        public DateTime BookingDateFrom { get; set; }
        public DateTime BookingDateTo { get; set; }
        public int UserID { get; set; }
    }
}