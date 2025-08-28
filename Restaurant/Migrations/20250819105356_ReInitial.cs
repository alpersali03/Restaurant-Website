using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class ReInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuestCount = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IconUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://cdn-icons-png.flaticon.com/512/1404/1404945.png", "Pizza" },
                    { 2, "https://cdn-icons-png.flaticon.com/512/1046/1046784.png", "Desserts" },
                    { 3, "https://cdn-icons-png.flaticon.com/512/1046/1046786.png", "Drinks" },
                    { 4, "https://cdn-icons-png.flaticon.com/512/1046/1046795.png", "Salads" },
                    { 5, "https://cdn-icons-png.flaticon.com/512/1404/1404948.png", "Pasta" },
                    { 6, "https://cdn-icons-png.flaticon.com/512/1046/1046803.png", "Soups" },
                    { 7, "https://cdn-icons-png.flaticon.com/512/1046/1046790.png", "Snacks" },
                    { 8, "https://cdn-icons-png.flaticon.com/512/1046/1046841.png", "Vegetarian" },
                    { 9, "https://cdn-icons-png.flaticon.com/512/1046/1046779.png", "Breakfast" },
                    { 10, "https://cdn-icons-png.flaticon.com/512/1404/1404942.png", "Burgers" }
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "EndDate", "Percentage", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 19, 0, 0, 0, 0, DateTimeKind.Local), 5, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), 5, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, new DateTime(2025, 9, 18, 0, 0, 0, 0, DateTimeKind.Local), 5, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Local), 5, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, new DateTime(2025, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), 5, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 6, new DateTime(2025, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), 5, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 7, new DateTime(2025, 8, 26, 0, 0, 0, 0, DateTimeKind.Local), 5, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Local), 5, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 9, new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Local), 5, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 10, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Local), 5, new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerName", "GuestCount", "Notes", "PhoneNumber", "ReservationDate", "Status" },
                values: new object[,]
                {
                    { 1, "John Smith", 2, "Window seat", "5551234567", new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, "Emily Johnson", 4, "", "5552345678", new DateTime(2025, 8, 19, 18, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 3, "Michael Lee", 3, "Birthday celebration", "5553456789", new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 4, "Sophia Davis", 5, "", "5554567890", new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 5, "David Brown", 2, "Romantic table", "5555678901", new DateTime(2025, 8, 19, 21, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 6, "Olivia Wilson", 6, "", "5556789012", new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 7, "James Miller", 3, "Non-smoking area", "5557890123", new DateTime(2025, 8, 19, 19, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 8, "Ava Martinez", 1, "", "5558901234", new DateTime(2025, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), 0 },
                    { 9, "William Anderson", 2, "", "5559012345", new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 10, "Emma Thomas", 4, "Birthday dinner", "5550123456", new DateTime(2025, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), 0 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "CustomerName", "Rating" },
                values: new object[,]
                {
                    { 1, "Amazing flavor!", new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8304), "John", 5 },
                    { 2, "Great taste but a bit salty.", new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8308), "Emily", 4 },
                    { 3, "Average meal.", new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8311), "Michael", 3 },
                    { 4, "Absolutely loved it!", new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8314), "Sophia", 5 },
                    { 5, "Not what I expected.", new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8317), "David", 2 },
                    { 6, "Tasty and well presented.", new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8319), "Olivia", 4 },
                    { 7, "Top quality!", new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8324), "James", 5 },
                    { 8, "It was okay.", new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8326), "Ava", 3 },
                    { 9, "Quick service, nice meal.", new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8329), "William", 4 },
                    { 10, "Best burger I've had!", new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8332), "Emma", 5 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsAvailable", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Classic tomato, mozzarella, and basil pizza.", "https://source.unsplash.com/600x400/?margherita,pizza", true, "Margherita", 49.90m },
                    { 2, 2, "Sweet pizza topped with Nutella and fruits.", "https://source.unsplash.com/600x400/?nutella,dessert", true, "Nutella Pizza", 59.90m },
                    { 3, 3, "330ml cold soft drink.", "https://source.unsplash.com/600x400/?coca-cola,drink", true, "Coca-Cola", 9.90m },
                    { 4, 4, "Chicken, croutons, and parmesan.", "https://source.unsplash.com/600x400/?caesar,salad", true, "Caesar Salad", 38.50m },
                    { 5, 5, "Spicy tomato pasta.", "https://source.unsplash.com/600x400/?penne,pasta", true, "Penne Arrabbiata", 42.00m },
                    { 6, 6, "Traditional Turkish red lentil soup.", "https://source.unsplash.com/600x400/?lentil,soup", true, "Lentil Soup", 19.00m },
                    { 7, 7, "Deep-fried mozzarella cheese.", "https://source.unsplash.com/600x400/?mozzarella,snacks", true, "Mozzarella Sticks", 27.00m },
                    { 8, 8, "Oven-roasted seasonal vegetables.", "https://source.unsplash.com/600x400/?vegetable,meal", true, "Vegetable Casserole", 35.00m },
                    { 9, 9, "Traditional Turkish breakfast assortment.", "https://source.unsplash.com/600x400/?breakfast,food", true, "Breakfast Platter", 69.00m },
                    { 10, 10, "Beef patty with cheddar cheese.", "https://source.unsplash.com/600x400/?cheeseburger", true, "Cheeseburger", 48.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdentityUserId",
                table: "Orders",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
