using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatingCalculator.Infrastructure.Migrations
{
    public partial class m10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserinformationId",
                table: "Dogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_UserinformationId",
                table: "Dogs",
                column: "UserinformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Userinformations_UserinformationId",
                table: "Dogs",
                column: "UserinformationId",
                principalTable: "Userinformations",
                principalColumn: "UserinformationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Userinformations_UserinformationId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_UserinformationId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "UserinformationId",
                table: "Dogs");
        }
    }
}
