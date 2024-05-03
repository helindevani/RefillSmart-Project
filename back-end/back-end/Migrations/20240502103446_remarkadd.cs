using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    /// <inheritdoc />
    public partial class remarkadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GasBookings",
                keyColumn: "BookingId",
                keyValue: new Guid("8a7a6eec-9124-4d69-9a8a-c7cd00a4a025"));

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "AdminRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "GasBookings",
                columns: new[] { "BookingId", "BookingDate", "ConnectionNo", "CreateDate", "CustomerAddress", "CustomerName", "CustomerPhoneNumber", "DeliveryDate", "NewConnectionFormConnectionNo", "Status", "UpdateDate" },
                values: new object[] { new Guid("6efa625d-f302-4b7a-b01d-f9ea3f3ee057"), new DateTime(2024, 5, 2, 10, 34, 46, 497, DateTimeKind.Utc).AddTicks(1995), new Guid("e3f3b30b-b841-4196-a665-f3eef01d7e58"), new DateTime(2024, 5, 2, 10, 34, 46, 497, DateTimeKind.Utc).AddTicks(2026), "123 Main Street", "John Doe", "1234567890", new DateTime(2024, 5, 9, 10, 34, 46, 497, DateTimeKind.Utc).AddTicks(1998), null, 0, new DateTime(2024, 5, 2, 10, 34, 46, 497, DateTimeKind.Utc).AddTicks(2027) });

            migrationBuilder.UpdateData(
                table: "NewConnectionForms",
                keyColumn: "ConnectionNo",
                keyValue: 123456,
                columns: new[] { "AppliedDate", "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 2, 10, 34, 46, 497, DateTimeKind.Utc).AddTicks(1785), new DateTime(2024, 5, 2, 10, 34, 46, 497, DateTimeKind.Utc).AddTicks(1791), new DateTime(2024, 5, 2, 10, 34, 46, 497, DateTimeKind.Utc).AddTicks(1792) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GasBookings",
                keyColumn: "BookingId",
                keyValue: new Guid("6efa625d-f302-4b7a-b01d-f9ea3f3ee057"));

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "AdminRequests");

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
    }
}
