using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    /// <inheritdoc />
    public partial class Notification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GasBookings",
                keyColumn: "BookingId",
                keyValue: new Guid("e4712e88-c714-40a6-bd6e-e24f8b5cf745"));

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "GasBookings",
                columns: new[] { "BookingId", "BookingDate", "ConnectionNo", "CreateDate", "CustomerAddress", "CustomerName", "CustomerPhoneNumber", "DeliveryDate", "NewConnectionFormConnectionNo", "Status", "UpdateDate" },
                values: new object[] { new Guid("7d0d9ec0-9fe6-4a85-974e-b0f12c32d0b0"), new DateTime(2024, 4, 27, 9, 7, 45, 322, DateTimeKind.Utc).AddTicks(179), new Guid("e3f3b30b-b841-4196-a665-f3eef01d7e58"), new DateTime(2024, 4, 27, 9, 7, 45, 322, DateTimeKind.Utc).AddTicks(223), "123 Main Street", "John Doe", "1234567890", new DateTime(2024, 5, 4, 9, 7, 45, 322, DateTimeKind.Utc).AddTicks(188), null, 0, new DateTime(2024, 4, 27, 9, 7, 45, 322, DateTimeKind.Utc).AddTicks(225) });

            migrationBuilder.UpdateData(
                table: "NewConnectionForms",
                keyColumn: "ConnectionNo",
                keyValue: 123456,
                columns: new[] { "AppliedDate", "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 27, 9, 7, 45, 321, DateTimeKind.Utc).AddTicks(9739), new DateTime(2024, 4, 27, 9, 7, 45, 321, DateTimeKind.Utc).AddTicks(9744), new DateTime(2024, 4, 27, 9, 7, 45, 321, DateTimeKind.Utc).AddTicks(9744) });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DeleteData(
                table: "GasBookings",
                keyColumn: "BookingId",
                keyValue: new Guid("7d0d9ec0-9fe6-4a85-974e-b0f12c32d0b0"));

            migrationBuilder.InsertData(
                table: "GasBookings",
                columns: new[] { "BookingId", "BookingDate", "ConnectionNo", "CreateDate", "CustomerAddress", "CustomerName", "CustomerPhoneNumber", "DeliveryDate", "NewConnectionFormConnectionNo", "Status", "UpdateDate" },
                values: new object[] { new Guid("e4712e88-c714-40a6-bd6e-e24f8b5cf745"), new DateTime(2024, 4, 26, 9, 13, 31, 938, DateTimeKind.Utc).AddTicks(3534), new Guid("e3f3b30b-b841-4196-a665-f3eef01d7e58"), new DateTime(2024, 4, 26, 9, 13, 31, 938, DateTimeKind.Utc).AddTicks(3565), "123 Main Street", "John Doe", "1234567890", new DateTime(2024, 5, 3, 9, 13, 31, 938, DateTimeKind.Utc).AddTicks(3537), null, 0, new DateTime(2024, 4, 26, 9, 13, 31, 938, DateTimeKind.Utc).AddTicks(3566) });

            migrationBuilder.UpdateData(
                table: "NewConnectionForms",
                keyColumn: "ConnectionNo",
                keyValue: 123456,
                columns: new[] { "AppliedDate", "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 4, 26, 9, 13, 31, 938, DateTimeKind.Utc).AddTicks(3303), new DateTime(2024, 4, 26, 9, 13, 31, 938, DateTimeKind.Utc).AddTicks(3311), new DateTime(2024, 4, 26, 9, 13, 31, 938, DateTimeKind.Utc).AddTicks(3311) });
        }
    }
}
