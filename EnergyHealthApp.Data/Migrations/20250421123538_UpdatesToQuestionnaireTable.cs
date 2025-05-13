using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyHealthApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatesToQuestionnaireTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Q1Answer",
                table: "EnergyQuestionnaires",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Q2Answer",
                table: "EnergyQuestionnaires",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Q3Answer",
                table: "EnergyQuestionnaires",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Q4Answer",
                table: "EnergyQuestionnaires",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Q5Answer",
                table: "EnergyQuestionnaires",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "EnergyQuestionnaires",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Q1Answer",
                table: "EnergyQuestionnaires");

            migrationBuilder.DropColumn(
                name: "Q2Answer",
                table: "EnergyQuestionnaires");

            migrationBuilder.DropColumn(
                name: "Q3Answer",
                table: "EnergyQuestionnaires");

            migrationBuilder.DropColumn(
                name: "Q4Answer",
                table: "EnergyQuestionnaires");

            migrationBuilder.DropColumn(
                name: "Q5Answer",
                table: "EnergyQuestionnaires");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "EnergyQuestionnaires");
        }
    }
}
