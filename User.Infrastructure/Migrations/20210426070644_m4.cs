using Microsoft.EntityFrameworkCore.Migrations;

namespace User.Infrastructure.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBreeder_Value",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsClubRepresentative_Value",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsOwner_Value",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBreeder_Value",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsClubRepresentative_Value",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOwner_Value",
                table: "Users",
                type: "bit",
                nullable: true);
        }
    }
}
