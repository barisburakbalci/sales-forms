using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sales_forms.Migrations
{
    /// <inheritdoc />
    public partial class Seeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "5199d0a6-4809-4e15-83ff-4ebbbae5e8fe");

            for (int i = 1; i <= 10; i++)
            {
                migrationBuilder.InsertData(
                    table: "Forms",
                    columns: new string[] { "Name", "FolderId" },
                    values: new object[] { $"FE Test Form {i}", 1L }
                );

                migrationBuilder.InsertData(
                    table: "Questions",
                    columns: new string[] { "Expression", "FormId" },
                    values: new object[] { $"FE Test Question {i}", 1L }
                );

                migrationBuilder.InsertData(
                    table: "Options",
                    columns: new string[] { "Value", "QuestionId", "Weight" },
                    values: new object[] { $"FE Test Option {i % 4}", (long) (i / 4) + 1, 10 }
                );

                migrationBuilder.InsertData(
                    table: "Answers",
                    columns: new string[] { "QuestionId", "OptionId", "ParticipantId" },
                    values: new object[] { (long) (i / 4) + 1, (long) (i / 4) + 1, 1L }
                );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "885aa077-cdc8-43b3-9c67-ddd2bec3efa8");
        }
    }
}
