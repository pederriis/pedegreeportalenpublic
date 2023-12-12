using Microsoft.EntityFrameworkCore.Migrations;

namespace User.Infrastructure.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnimalName_Value",
                table: "Animals",
                newName: "Name_Value");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted_Value",
                table: "Animals",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted_Value",
                table: "Animals");

            migrationBuilder.RenameColumn(
                name: "Name_Value",
                table: "Animals",
                newName: "AnimalName_Value");
        }
    }
}
