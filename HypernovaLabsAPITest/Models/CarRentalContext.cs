using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypernovaLabsAPITest.Models
{
    public class CarRentalContext : DbContext
    {
        string initColors = "Blanco,Negro,Rojo,Azul";
        string initBrands = "Ford,Chevrolet,Tesla";

        public CarRentalContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var counter = 1;
            var r = new Random();

            var colors = new List<Color>();
            foreach (var c in initColors.Split(','))
            {
                colors.Add(new Color { ColorID = counter, ColorName = c });
                counter++;
            }
            modelBuilder.Entity<Color>().HasData(colors);

            counter = 1;
            var brands = new List<Brand>();
            foreach (var c in initBrands.Split(','))
            {
                brands.Add(new Brand { BrandID = counter, BrandName = c });
                counter++;
            }
            modelBuilder.Entity<Brand>().HasData(brands);

            counter = 1;
            var models = new List<CarModel>();
            foreach (var b in brands)
            {
                for (int i = 1; i < 5; i++)
                {
                    models.Add(new CarModel
                    {
                        ModelID = counter,
                        BrandID = b.BrandID,
                        ColorID = colors[r.Next(0, colors.Count)].ColorID,
                        ModelName = $"Modelo {i}",
                        ModelYear = 2000 + i,
                        Inventory = r.Next(1, 10),
                        DayPrice = Convert.ToDecimal(r.NextDouble() * 10.1)
                    });
                    counter++;
                }
            }
            modelBuilder.Entity<CarModel>().HasData(models);

            modelBuilder.Entity<User>().HasData(new User
            {
                UserID = 1,
                FirstName = "Pedro",
                LastName = "Perez",
                Email = "pedro@perez.com",
                Password = "password",
                CreationDate = DateTime.Now
            });
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}