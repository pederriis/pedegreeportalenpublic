using Microsoft.EntityFrameworkCore.Migrations;

namespace Kennel.Infrastructure.Migrations
{
    public partial class ChildAmountRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildAmount_Value",
                table: "Litters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildAmount_Value",
                table: "Litters",
                type: "int",
                nullable: true);
        }
    }
}
