using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatingCalculator.Infrastructure.Migrations
{
    public partial class m22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Child");

            migrationBuilder.AddColumn<Guid>(
                name: "HomeLitterId",
                table: "Dogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_HomeLitterId",
                table: "Dogs",
                column: "HomeLitterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Litters_HomeLitterId",
                table: "Dogs",
                column: "HomeLitterId",
                principalTable: "Litters",
                principalColumn: "LitterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Litters_HomeLitterId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_HomeLitterId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "HomeLitterId",
                table: "Dogs");

            migrationBuilder.CreateTable(
                name: "Child",
                columns: table => new
                {
                    ChildId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Child", x => x.ChildId);
                    table.ForeignKey(
                        name: "FK_Child_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "DogId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Child_Litters_LitterId",
                        column: x => x.LitterId,
                        principalTable: "Litters",
                        principalColumn: "LitterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Child_DogId",
                table: "Child",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_Child_LitterId",
                table: "Child",
                column: "LitterId");
        }
    }
}
