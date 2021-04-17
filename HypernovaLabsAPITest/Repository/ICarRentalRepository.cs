using HypernovaLabsAPITest.Models;
using HypernovaLabsAPITest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypernovaLabsAPITest.Repository
{
    public interface ICarRentalRepository
    {
        Task<int> RegisterUser(UserViewModel user);
        User Login(UserViewModel user);
        string GeneratePasswordHash(string password);
        List<UserBookingsViewModel> UserBookings(int userID);
        public UserViewModel UserInfo(int userID);
        List<Brand> GetCarBrands();
        List<CarModel> GetCarModels();
        List<InventoryViewModel> GetAvailableInventory();
        void CreateBooking(CreateBookingViewModel data);
    }
}