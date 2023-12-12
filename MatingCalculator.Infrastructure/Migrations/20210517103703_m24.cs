using Microsoft.EntityFrameworkCore.Migrations;

namespace MatingCalculator.Infrastructure.Migrations
{
    public partial class m24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender_Value",
                table: "Parentings");

            migrationBuilder.AddColumn<double>(
                name: "Probability_Value",
                table: "Diseases",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Probability_Value",
                table: "Diseases");

            migrationBuilder.AddColumn<bool>(
                name: "Gender_Value",
                table: "Parentings",
                type: "bit",
                nullable: true);
        }
    }
}
