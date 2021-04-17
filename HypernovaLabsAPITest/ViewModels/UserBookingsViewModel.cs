using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypernovaLabsAPITest.ViewModels
{
    public class UserBookingsViewModel
    {
        public int BookingID { get; set; }
        public DateTime BookingDateFrom { get; set; }
        public DateTime BookingDateTo { get; set; }
        public int TotalDays { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
    }
}