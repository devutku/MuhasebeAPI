using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuhasebeAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTaxOfficeAndAddressToCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Company",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxOffice",
                table: "Company",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 40, 9, 738, DateTimeKind.Utc).AddTicks(6801));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 40, 9, 738, DateTimeKind.Utc).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 40, 9, 738, DateTimeKind.Utc).AddTicks(6817));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 40, 9, 738, DateTimeKind.Utc).AddTicks(6818));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 40, 9, 738, DateTimeKind.Utc).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 16, 17, 40, 9, 738, DateTimeKind.Utc).AddTicks(6820));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "TaxOffice",
                table: "Company");

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 11, 10, 44, 22, 686, DateTimeKind.Utc).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 11, 10, 44, 22, 686, DateTimeKind.Utc).AddTicks(9567));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 11, 10, 44, 22, 686, DateTimeKind.Utc).AddTicks(9569));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 11, 10, 44, 22, 686, DateTimeKind.Utc).AddTicks(9570));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 11, 10, 44, 22, 686, DateTimeKind.Utc).AddTicks(9571));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 11, 10, 44, 22, 686, DateTimeKind.Utc).AddTicks(9572));
        }
    }
}
