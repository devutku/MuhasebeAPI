using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuhasebeAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTypeEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 11, 26, 1, 142, DateTimeKind.Utc).AddTicks(4305));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 11, 26, 1, 142, DateTimeKind.Utc).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 11, 26, 1, 142, DateTimeKind.Utc).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 11, 26, 1, 142, DateTimeKind.Utc).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 11, 26, 1, 142, DateTimeKind.Utc).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 11, 26, 1, 142, DateTimeKind.Utc).AddTicks(4319));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 11, 20, 11, 712, DateTimeKind.Utc).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 11, 20, 11, 712, DateTimeKind.Utc).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 11, 20, 11, 712, DateTimeKind.Utc).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 11, 20, 11, 712, DateTimeKind.Utc).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 11, 20, 11, 712, DateTimeKind.Utc).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 11, 20, 11, 712, DateTimeKind.Utc).AddTicks(2415));
        }
    }
}
