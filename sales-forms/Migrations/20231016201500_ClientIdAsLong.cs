using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sales_forms.Migrations
{
    /// <inheritdoc />
    public partial class ClientIdAsLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "49dc063f-9278-4d44-b1cf-310871478ebe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "28c931c0-6190-4b0e-b41d-68be7656498e");
        }
    }
}
