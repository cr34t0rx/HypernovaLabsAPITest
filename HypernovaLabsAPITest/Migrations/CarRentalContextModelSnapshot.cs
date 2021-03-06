// <auto-generated />
using System;
using HypernovaLabsAPITest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HypernovaLabsAPITest.Migrations
{
    [DbContext(typeof(CarRentalContext))]
    partial class CarRentalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HypernovaLabsAPITest.Models.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BookingDateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("ClientFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelID")
                        .HasColumnType("int");

                    b.Property<int>("TotalDays")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("BookingID");

                    b.HasIndex("ModelID");

                    b.HasIndex("UserID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("HypernovaLabsAPITest.Models.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandID");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            BrandID = 1,
                            BrandName = "Ford"
                        },
                        new
                        {
                            BrandID = 2,
                            BrandName = "Chevrolet"
                        },
                        new
                        {
                            BrandID = 3,
                            BrandName = "Tesla"
                        });
                });

            modelBuilder.Entity("HypernovaLabsAPITest.Models.CarModel", b =>
                {
                    b.Property<int>("ModelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.Property<int>("ColorID")
                        .HasColumnType("int");

                    b.Property<decimal>("DayPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.HasKey("ModelID");

                    b.HasIndex("BrandID");

                    b.HasIndex("ColorID");

                    b.ToTable("CarModels");

                    b.HasData(
                        new
                        {
                            ModelID = 1,
                            BrandID = 1,
                            ColorID = 3,
                            DayPrice = 3.10053638755369m,
                            Inventory = 6,
                            ModelName = "Modelo 1",
                            ModelYear = 2001
                        },
                        new
                        {
                            ModelID = 2,
                            BrandID = 1,
                            ColorID = 1,
                            DayPrice = 8.29840317610577m,
                            Inventory = 7,
                            ModelName = "Modelo 2",
                            ModelYear = 2002
                        },
                        new
                        {
                            ModelID = 3,
                            BrandID = 1,
                            ColorID = 3,
                            DayPrice = 6.15401081887726m,
                            Inventory = 9,
                            ModelName = "Modelo 3",
                            ModelYear = 2003
                        },
                        new
                        {
                            ModelID = 4,
                            BrandID = 1,
                            ColorID = 2,
                            DayPrice = 0.919242403432374m,
                            Inventory = 6,
                            ModelName = "Modelo 4",
                            ModelYear = 2004
                        },
                        new
                        {
                            ModelID = 5,
                            BrandID = 2,
                            ColorID = 3,
                            DayPrice = 5.93866211014737m,
                            Inventory = 3,
                            ModelName = "Modelo 1",
                            ModelYear = 2001
                        },
                        new
                        {
                            ModelID = 6,
                            BrandID = 2,
                            ColorID = 2,
                            DayPrice = 1.34892628111361m,
                            Inventory = 2,
                            ModelName = "Modelo 2",
                            ModelYear = 2002
                        },
                        new
                        {
                            ModelID = 7,
                            BrandID = 2,
                            ColorID = 1,
                            DayPrice = 4.75348944596643m,
                            Inventory = 8,
                            ModelName = "Modelo 3",
                            ModelYear = 2003
                        },
                        new
                        {
                            ModelID = 8,
                            BrandID = 2,
                            ColorID = 2,
                            DayPrice = 9.84840251735803m,
                            Inventory = 6,
                            ModelName = "Modelo 4",
                            ModelYear = 2004
                        },
                        new
                        {
                            ModelID = 9,
                            BrandID = 3,
                            ColorID = 3,
                            DayPrice = 4.87252537802445m,
                            Inventory = 6,
                            ModelName = "Modelo 1",
                            ModelYear = 2001
                        },
                        new
                        {
                            ModelID = 10,
                            BrandID = 3,
                            ColorID = 2,
                            DayPrice = 9.51205918593894m,
                            Inventory = 6,
                            ModelName = "Modelo 2",
                            ModelYear = 2002
                        },
                        new
                        {
                            ModelID = 11,
                            BrandID = 3,
                            ColorID = 3,
                            DayPrice = 2.96829383008568m,
                            Inventory = 8,
                            ModelName = "Modelo 3",
                            ModelYear = 2003
                        },
                        new
                        {
                            ModelID = 12,
                            BrandID = 3,
                            ColorID = 1,
                            DayPrice = 7.18284205742313m,
                            Inventory = 5,
                            ModelName = "Modelo 4",
                            ModelYear = 2004
                        });
                });

            modelBuilder.Entity("HypernovaLabsAPITest.Models.Color", b =>
                {
                    b.Property<int>("ColorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColorID");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            ColorID = 1,
                            ColorName = "Blanco"
                        },
                        new
                        {
                            ColorID = 2,
                            ColorName = "Negro"
                        },
                        new
                        {
                            ColorID = 3,
                            ColorName = "Rojo"
                        },
                        new
                        {
                            ColorID = 4,
                            ColorName = "Azul"
                        });
                });

            modelBuilder.Entity("HypernovaLabsAPITest.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            CreationDate = new DateTime(2021, 4, 17, 0, 20, 42, 819, DateTimeKind.Local).AddTicks(7467),
                            Email = "pedro@perez.com",
                            FirstName = "Pedro",
                            LastName = "Perez",
                            Password = "password"
                        });
                });

            modelBuilder.Entity("HypernovaLabsAPITest.Models.Booking", b =>
                {
                    b.HasOne("HypernovaLabsAPITest.Models.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("ModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HypernovaLabsAPITest.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HypernovaLabsAPITest.Models.CarModel", b =>
                {
                    b.HasOne("HypernovaLabsAPITest.Models.Brand", "Brand")
                        .WithMany("CarModels")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HypernovaLabsAPITest.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Color");
                });

            modelBuilder.Entity("HypernovaLabsAPITest.Models.Brand", b =>
                {
                    b.Navigation("CarModels");
                });
#pragma warning restore 612, 618
        }
    }
}
