using HypernovaLabsAPITest.Models;
using HypernovaLabsAPITest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HypernovaLabsAPITest.Repository
{
    public class CarRentalRepository : ICarRentalRepository
    {
        CarRentalContext _context;
        public CarRentalRepository(CarRentalContext context) => _context = context;

        public async Task<int> RegisterUser(UserViewModel user)
        {
            var u = _context.Users.FirstOrDefault(x => x.Email == user.Email.Trim().ToLower());
            if (u == null)
            {
                u = new User();
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.Email = user.Email.Trim().ToLower();
                u.Password = GeneratePasswordHash(user.Password);
                u.CreationDate = DateTime.Now;
                _context.Users.Add(u);

                await _context.SaveChangesAsync();
                return u.UserID;
            }

            return -1;
        }

        public User Login(UserViewModel user)
        {
            var pass = GeneratePasswordHash(user.Password);

            var u = _context.Users.FirstOrDefault(x =>
            x.Email == user.Email.Trim().ToLower() &&
            x.Password == pass
            );

            return u;
        }

        public List<UserBookingsViewModel> UserBookings(int userID)
        {
            return _context.Bookings.Where(x => x.UserID == userID).Select(x => new UserBookingsViewModel
            {
                BookingID = x.BookingID,
                BookingDateFrom = x.BookingDateFrom,
                BookingDateTo = x.BookingDateTo,
                TotalDays = x.TotalDays,
                TotalPrice = x.TotalPrice,
                CreationDate = x.CreationDate,
                BrandName = x.CarModel.Brand.BrandName,
                ModelName = x.CarModel.ModelName,
                ColorName = x.CarModel.Color.ColorName,
                ModelYear = x.CarModel.ModelYear
            }).ToList();
        }

        public async void CreateBooking(CreateBookingViewModel data)
        {
            var m = _context.CarModels.FirstOrDefault(x => x.ModelID == data.ModelID);

            var b = new Booking();
            b.BookingDateFrom = data.BookingDateFrom;
            b.BookingDateTo = data.BookingDateTo;
            b.TotalDays = Convert.ToInt32((data.BookingDateTo - data.BookingDateFrom).TotalDays);
            b.TotalPrice = b.TotalDays * m.DayPrice;

            if (data.UserID == -1)
            {
                b.ClientFirstName = data.FirstName;
                b.ClientLastName = data.LastName;
                b.Email = data.Email;
            }
            else
                b.UserID = data.UserID;

            b.ModelID = data.ModelID;
            b.CreationDate = DateTime.Now;

            _context.Bookings.Add(b);
            await _context.SaveChangesAsync();
        }

        public UserViewModel UserInfo(int userID)
        {
            return _context.Users.Where(x => x.UserID == userID).Select(x => new UserViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email
            }).FirstOrDefault();
        }

        public List<Brand> GetCarBrands()
        {
            return _context.Brands.ToList();
        }

        public List<CarModel> GetCarModels()
        {
            return _context.CarModels.ToList();
        }

        public List<InventoryViewModel> GetAvailableInventory()
        {
            return _context.CarModels.Select(x => new InventoryViewModel
            {
                ModelID = x.ModelID,
                BrandName = x.Brand.BrandName,
                ModelName = x.ModelName,
                ColorName = x.Color.ColorName,
                ModelYear = x.ModelYear,
                Inventory = x.Inventory - _context.Bookings.Where(y => y.ModelID == x.ModelID).Count(),
                DayPrice = x.DayPrice
            }).Where(x => x.Inventory > 0).ToList();
        }

        public string GeneratePasswordHash(string password)
        {
            byte[] hash;
            var salt = "ml+VZEBR0IPTlQsN9A+uI48i9uYJkJBhjZla2nW9e1i8ZeSaEO96wenAVU/R3WcNe9yOPVmPZkQRndqptLxBoxGU0F5yKjIHo+BUcOAOjySCyvg2ZAGwNJiOjSELdqlQjmxVnfPThq1puRMVdnlIojS5ZLhGX9xFHyqIJjVKIlm7bSQWjL/v1oB9R6IPspmG2LmiQEAMPujlZOpLXg/e5iykT6bTCSuJkpIUOLhf6XuK800WWWF+aiYppuoFj9gk7k3WFT7aLcAUVinEjueXLFobkABm545Jcj6lQtK8HMhLNYA5HTB6ac557SN/XzsM1UjpTuX18FrdvoxlogW5Qg==";
            using (var crypto = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10240))
            {
                hash = crypto.GetBytes(20);
            }

            return Convert.ToBase64String(hash);
        }
    }
}