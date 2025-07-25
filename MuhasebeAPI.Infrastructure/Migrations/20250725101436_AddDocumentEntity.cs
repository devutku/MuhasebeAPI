using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuhasebeAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentType = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    UploadedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 10, 14, 36, 261, DateTimeKind.Utc).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 10, 14, 36, 261, DateTimeKind.Utc).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 10, 14, 36, 261, DateTimeKind.Utc).AddTicks(8678));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 10, 14, 36, 261, DateTimeKind.Utc).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 10, 14, 36, 261, DateTimeKind.Utc).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "AccountCategory",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 10, 14, 36, 261, DateTimeKind.Utc).AddTicks(8682));

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CompanyId",
                table: "Documents",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

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
    }
}
