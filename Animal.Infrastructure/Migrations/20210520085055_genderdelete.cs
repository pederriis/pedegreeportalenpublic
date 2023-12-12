using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Infrastructure.Migrations
{
    public partial class genderdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender_Value",
                table: "Parentings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Gender_Value",
                table: "Parentings",
                type: "bit",
                nullable: true);
        }
    }
}
