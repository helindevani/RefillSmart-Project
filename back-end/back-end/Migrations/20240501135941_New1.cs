using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    /// <inheritdoc />
    public partial class New1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GasBookings",
                keyColumn: "BookingId",
                keyValue: new Guid("096f0943-dcb5-4f2f-be48-de30b9e184e0"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "GasBookings",
                columns: new[] { "BookingId", "BookingDate", "ConnectionNo", "CreateDate", "CustomerAddress", "CustomerName", "CustomerPhoneNumber", "DeliveryDate", "NewConnectionFormConnectionNo", "Status", "UpdateDate" },
                values: new object[] { new Guid("8a7a6eec-9124-4d69-9a8a-c7cd00a4a025"), new DateTime(2024, 5, 1, 13, 59, 41, 613, DateTimeKind.Utc).AddTicks(1806), new Guid("e3f3b30b-b841-4196-a665-f3eef01d7e58"), new DateTime(2024, 5, 1, 13, 59, 41, 613, DateTimeKind.Utc).AddTicks(1837), "123 Main Street", "John Doe", "1234567890", new DateTime(2024, 5, 8, 13, 59, 41, 613, DateTimeKind.Utc).AddTicks(1810), null, 0, new DateTime(2024, 5, 1, 13, 59, 41, 613, DateTimeKind.Utc).AddTicks(1838) });

            migrationBuilder.UpdateData(
                table: "NewConnectionForms",
                keyColumn: "ConnectionNo",
                keyValue: 123456,
                columns: new[] { "AppliedDate", "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 1, 13, 59, 41, 613, DateTimeKind.Utc).AddTicks(1616), new DateTime(2024, 5, 1, 13, 59, 41, 613, DateTimeKind.Utc).AddTicks(1620), new DateTime(2024, 5, 1, 13, 59, 41, 613, DateTimeKind.Utc).AddTicks(1621) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GasBookings",
                keyColumn: "BookingId",
                keyValue: new Guid("8a7a6eec-9124-4d69-9a8a-c7cd00a4a025"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

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
    }
}
