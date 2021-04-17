using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HypernovaLabsAPITest.Migrations
{
    public partial class HypernovaLabsAPITestModelsCarRentalContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    ModelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    ColorID = table.Column<int>(type: "int", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    DayPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.ModelID);
                    table.ForeignKey(
                        name: "FK_CarModels_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModels_Colors_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Colors",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingDateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalDays = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ModelID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_CarModels_ModelID",
                        column: x => x.ModelID,
                        principalTable: "CarModels",
                        principalColumn: "ModelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandID", "BrandName" },
                values: new object[,]
                {
                    { 1, "Ford" },
                    { 2, "Chevrolet" },
                    { 3, "Tesla" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "ColorID", "ColorName" },
                values: new object[,]
                {
                    { 1, "Blanco" },
                    { 2, "Negro" },
                    { 3, "Rojo" },
                    { 4, "Azul" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "CreationDate", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1, new DateTime(2021, 4, 17, 0, 20, 42, 819, DateTimeKind.Local).AddTicks(7467), "pedro@perez.com", "Pedro", "Perez", "password" });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "ModelID", "BrandID", "ColorID", "DayPrice", "Inventory", "ModelName", "ModelYear" },
                values: new object[,]
                {
                    { 2, 1, 1, 8.29840317610577m, 7, "Modelo 2", 2002 },
                    { 7, 2, 1, 4.75348944596643m, 8, "Modelo 3", 2003 },
                    { 12, 3, 1, 7.18284205742313m, 5, "Modelo 4", 2004 },
                    { 4, 1, 2, 0.919242403432374m, 6, "Modelo 4", 2004 },
                    { 6, 2, 2, 1.34892628111361m, 2, "Modelo 2", 2002 },
                    { 8, 2, 2, 9.84840251735803m, 6, "Modelo 4", 2004 },
                    { 10, 3, 2, 9.51205918593894m, 6, "Modelo 2", 2002 },
                    { 1, 1, 3, 3.10053638755369m, 6, "Modelo 1", 2001 },
                    { 3, 1, 3, 6.15401081887726m, 9, "Modelo 3", 2003 },
                    { 5, 2, 3, 5.93866211014737m, 3, "Modelo 1", 2001 },
                    { 9, 3, 3, 4.87252537802445m, 6, "Modelo 1", 2001 },
                    { 11, 3, 3, 2.96829383008568m, 8, "Modelo 3", 2003 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ModelID",
                table: "Bookings",
                column: "ModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserID",
                table: "Bookings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_BrandID",
                table: "CarModels",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_ColorID",
                table: "CarModels",
                column: "ColorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Colors");
        }
    }
}
