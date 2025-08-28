using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class CouponCodeUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Coupons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "EndDate", "StartDate" },
                values: new object[] { "HELLO2025", new DateTime(2025, 9, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "EndDate", "StartDate" },
                values: new object[] { "HELLOSUMMER", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "EndDate", "StartDate" },
                values: new object[] { "WELCOME", new DateTime(2025, 9, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Code", "EndDate", "StartDate" },
                values: new object[] { "BIGDISCOUNT", new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Code", "EndDate", "StartDate" },
                values: new object[] { "BESTPLACE", new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Code", "EndDate", "StartDate" },
                values: new object[] { "MEMORIES", new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Code", "EndDate", "StartDate" },
                values: new object[] { "HAVEFUN25", new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Code", "EndDate", "StartDate" },
                values: new object[] { "ANNIVERSARRY", new DateTime(2025, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Code", "EndDate", "StartDate" },
                values: new object[] { "LETSDRINK", new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Code", "EndDate", "StartDate" },
                values: new object[] { "LETSEAT", new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Coupons");

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 8, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 8, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 19, 18, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 19, 21, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 6,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 7,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 19, 19, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 8,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 9,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 10,
                column: "ReservationDate",
                value: new DateTime(2025, 8, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8304));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8308));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8311));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8314));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8317));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8319));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8324));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8326));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 19, 13, 53, 55, 40, DateTimeKind.Local).AddTicks(8332));
        }
    }
}
