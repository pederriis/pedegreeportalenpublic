using Microsoft.EntityFrameworkCore.Migrations;

namespace MatingCalculator.Infrastructure.Migrations
{
    public partial class m23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Gender_Value",
                table: "Parentings",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender_Value",
                table: "Parentings");
        }
    }
}
