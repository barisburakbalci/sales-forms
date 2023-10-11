using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sales_forms.Migrations
{
    /// <inheritdoc />
    public partial class Seeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Test Client" });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Test Participant" });

            migrationBuilder.InsertData(
                table: "Forms",
                columns: new[] { "Id", "ClientId", "Name" },
                values: new object[] { 1L, 1L, "Test Form" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Expression", "FormId" },
                values: new object[] { 1L, "Test Question", 1L });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "ParticipantId", "QuestionId", "Value", "Weight" },
                values: new object[] { 1L, 1L, 1L, "Test Answer", 10 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "QuestionId", "Value", "Weight" },
                values: new object[] { 1L, 1L, "Test Option", 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
