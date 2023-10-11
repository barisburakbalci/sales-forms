using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sales_forms.Migrations
{
    /// <inheritdoc />
    public partial class ScoreRemoval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Participants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Participants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
