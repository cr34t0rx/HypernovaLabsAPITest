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
                    ColorID = table.Column<int>(type: "int", nullable: false)
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
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelID = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    DayPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_Inventories_CarModels_ModelID",
                        column: x => x.ModelID,
                        principalTable: "CarModels",
                        principalColumn: "ModelID",
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
                table: "CarModels",
                columns: new[] { "ModelID", "BrandID", "ColorID", "ModelName", "ModelYear" },
                values: new object[,]
                {
                    { 4, 1, 1, "Modelo 4", 2004 },
                    { 7, 2, 1, "Modelo 3", 2003 },
                    { 8, 2, 1, "Modelo 4", 2004 },
                    { 2, 1, 2, "Modelo 2", 2002 },
                    { 9, 3, 2, "Modelo 1", 2001 },
                    { 3, 1, 3, "Modelo 3", 2003 },
                    { 10, 3, 3, "Modelo 2", 2002 },
                    { 1, 1, 4, "Modelo 1", 2001 },
                    { 5, 2, 4, "Modelo 1", 2001 },
                    { 6, 2, 4, "Modelo 2", 2002 },
                    { 11, 3, 4, "Modelo 3", 2003 },
                    { 12, 3, 4, "Modelo 4", 2004 }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryID", "DayPrice", "ModelID", "Total" },
                values: new object[,]
                {
                    { 4, 2.98061566994554m, 4, 8 },
                    { 7, 4.04844861768579m, 7, 6 },
                    { 8, 5.7949407294369m, 8, 9 },
                    { 2, 8.85846800364483m, 2, 9 },
                    { 9, 0.330675572729984m, 9, 1 },
                    { 3, 1.86569340287973m, 3, 3 },
                    { 10, 2.38738872724929m, 10, 5 },
                    { 1, 9.91017914042351m, 1, 3 },
                    { 5, 5.24224355409026m, 5, 7 },
                    { 6, 3.8172259649342m, 6, 9 },
                    { 11, 6.58180789872157m, 11, 9 },
                    { 12, 2.305686498436m, 12, 1 }
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

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ModelID",
                table: "Inventories",
                column: "ModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Colors");
        }
    }
}
