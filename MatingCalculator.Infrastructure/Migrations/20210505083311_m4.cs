using Microsoft.EntityFrameworkCore.Migrations;

namespace MatingCalculator.Infrastructure.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubdRaceId_Value",
                table: "Dogs",
                newName: "SubRaceId_Value");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubRaceId_Value",
                table: "Dogs",
                newName: "SubdRaceId_Value");
        }
    }
}
