using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class NewControllersAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReviewId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReviewId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReviewId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ReviewId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ReviewId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ReviewId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ReviewId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ReviewId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ReviewId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 25, 18, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 25, 21, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 6,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 7,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 25, 19, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 8,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 9,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 10,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ProductId" },
                values: new object[] { new DateTime(2025, 8, 25, 11, 42, 5, 49, DateTimeKind.Local).AddTicks(727), 0 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ProductId" },
                values: new object[] { new DateTime(2025, 8, 25, 11, 42, 5, 49, DateTimeKind.Local).AddTicks(729), 0 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ProductId" },
                values: new object[] { new DateTime(2025, 8, 25, 11, 42, 5, 49, DateTimeKind.Local).AddTicks(731), 0 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ProductId" },
                values: new object[] { new DateTime(2025, 8, 25, 11, 42, 5, 49, DateTimeKind.Local).AddTicks(733), 0 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ProductId" },
                values: new object[] { new DateTime(2025, 8, 25, 11, 42, 5, 49, DateTimeKind.Local).AddTicks(735), 0 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ProductId" },
                values: new object[] { new DateTime(2025, 8, 25, 11, 42, 5, 49, DateTimeKind.Local).AddTicks(736), 0 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ProductId" },
                values: new object[] { new DateTime(2025, 8, 25, 11, 42, 5, 49, DateTimeKind.Local).AddTicks(738), 0 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ProductId" },
                values: new object[] { new DateTime(2025, 8, 25, 11, 42, 5, 49, DateTimeKind.Local).AddTicks(739), 0 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ProductId" },
                values: new object[] { new DateTime(2025, 8, 25, 11, 42, 5, 49, DateTimeKind.Local).AddTicks(741), 0 });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ProductId" },
                values: new object[] { new DateTime(2025, 8, 25, 11, 42, 5, 49, DateTimeKind.Local).AddTicks(743), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ReviewId",
                table: "Products",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Reviews_ReviewId",
                table: "Products",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Reviews_ReviewId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ReviewId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 22, 18, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 22, 21, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 6,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 7,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 22, 19, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 8,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 9,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 10,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 13, 34, 54, 303, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 13, 34, 54, 303, DateTimeKind.Local).AddTicks(7725));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 13, 34, 54, 303, DateTimeKind.Local).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 13, 34, 54, 303, DateTimeKind.Local).AddTicks(7729));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 13, 34, 54, 303, DateTimeKind.Local).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 13, 34, 54, 303, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 13, 34, 54, 303, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 13, 34, 54, 303, DateTimeKind.Local).AddTicks(7738));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 13, 34, 54, 303, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 22, 13, 34, 54, 303, DateTimeKind.Local).AddTicks(7742));
        }
    }
}
