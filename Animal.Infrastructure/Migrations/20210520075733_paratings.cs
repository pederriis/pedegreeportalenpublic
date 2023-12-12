using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Infrastructure.Migrations
{
    public partial class paratings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Parrents");

            migrationBuilder.AddColumn<Guid>(
                name: "LitterId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Parentings",
                columns: table => new
                {
                    ParentingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Gender_Value = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parentings", x => x.ParentingId);
                    table.ForeignKey(
                        name: "FK_Parentings_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parentings_Litters_LitterId",
                        column: x => x.LitterId,
                        principalTable: "Litters",
                        principalColumn: "LitterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_LitterId",
                table: "Animals",
                column: "LitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Parentings_AnimalId",
                table: "Parentings",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Parentings_LitterId",
                table: "Parentings",
                column: "LitterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Litters_LitterId",
                table: "Animals",
                column: "LitterId",
                principalTable: "Litters",
                principalColumn: "LitterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Litters_LitterId",
                table: "Animals");

            migrationBuilder.DropTable(
                name: "Parentings");

            migrationBuilder.DropIndex(
                name: "IX_Animals_LitterId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "LitterId",
                table: "Animals");

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    ChildId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.ChildId);
                    table.ForeignKey(
                        name: "FK_Children_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Children_Litters_LitterId",
                        column: x => x.LitterId,
                        principalTable: "Litters",
                        principalColumn: "LitterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parrents",
                columns: table => new
                {
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parrents", x => x.ParrentId);
                    table.ForeignKey(
                        name: "FK_Parrents_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parrents_Litters_LitterId",
                        column: x => x.LitterId,
                        principalTable: "Litters",
                        principalColumn: "LitterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Children_AnimalId",
                table: "Children",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_LitterId",
                table: "Children",
                column: "LitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Parrents_AnimalId",
                table: "Parrents",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Parrents_LitterId",
                table: "Parrents",
                column: "LitterId");
        }
    }
}
