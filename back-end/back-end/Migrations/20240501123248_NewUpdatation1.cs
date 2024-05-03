using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdatation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GasBookings",
                keyColumn: "BookingId",
                keyValue: new Guid("8fea0988-208a-4fcb-a1c2-9a4b4c500f9b"));

            migrationBuilder.InsertData(
                table: "GasBookings",
                columns: new[] { "BookingId", "BookingDate", "ConnectionNo", "CreateDate", "CustomerAddress", "CustomerName", "CustomerPhoneNumber", "DeliveryDate", "NewConnectionFormConnectionNo", "Status", "UpdateDate" },
                values: new object[] { new Guid("096f0943-dcb5-4f2f-be48-de30b9e184e0"), new DateTime(2024, 5, 1, 12, 32, 47, 783, DateTimeKind.Utc).AddTicks(5074), new Guid("e3f3b30b-b841-4196-a665-f3eef01d7e58"), new DateTime(2024, 5, 1, 12, 32, 47, 783, DateTimeKind.Utc).AddTicks(5111), "123 Main Street", "John Doe", "1234567890", new DateTime(2024, 5, 8, 12, 32, 47, 783, DateTimeKind.Utc).AddTicks(5080), null, 0, new DateTime(2024, 5, 1, 12, 32, 47, 783, DateTimeKind.Utc).AddTicks(5112) });

            migrationBuilder.UpdateData(
                table: "NewConnectionForms",
                keyColumn: "ConnectionNo",
                keyValue: 123456,
                columns: new[] { "AppliedDate", "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 1, 12, 32, 47, 783, DateTimeKind.Utc).AddTicks(4866), new DateTime(2024, 5, 1, 12, 32, 47, 783, DateTimeKind.Utc).AddTicks(4871), new DateTime(2024, 5, 1, 12, 32, 47, 783, DateTimeKind.Utc).AddTicks(4872) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GasBookings",
                keyColumn: "BookingId",
                keyValue: new Guid("096f0943-dcb5-4f2f-be48-de30b9e184e0"));

            migrationBuilder.InsertData(
                table: "GasBookings",
                columns: new[] { "BookingId", "BookingDate", "ConnectionNo", "CreateDate", "CustomerAddress", "CustomerName", "CustomerPhoneNumber", "DeliveryDate", "NewConnectionFormConnectionNo", "Status", "UpdateDate" },
                values: new object[] { new Guid("8fea0988-208a-4fcb-a1c2-9a4b4c500f9b"), new DateTime(2024, 5, 1, 12, 32, 8, 496, DateTimeKind.Utc).AddTicks(925), new Guid("e3f3b30b-b841-4196-a665-f3eef01d7e58"), new DateTime(2024, 5, 1, 12, 32, 8, 496, DateTimeKind.Utc).AddTicks(952), "123 Main Street", "John Doe", "1234567890", new DateTime(2024, 5, 8, 12, 32, 8, 496, DateTimeKind.Utc).AddTicks(928), null, 0, new DateTime(2024, 5, 1, 12, 32, 8, 496, DateTimeKind.Utc).AddTicks(953) });

            migrationBuilder.UpdateData(
                table: "NewConnectionForms",
                keyColumn: "ConnectionNo",
                keyValue: 123456,
                columns: new[] { "AppliedDate", "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 1, 12, 32, 8, 496, DateTimeKind.Utc).AddTicks(755), new DateTime(2024, 5, 1, 12, 32, 8, 496, DateTimeKind.Utc).AddTicks(759), new DateTime(2024, 5, 1, 12, 32, 8, 496, DateTimeKind.Utc).AddTicks(759) });
        }
    }
}
