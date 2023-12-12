using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kennel.Infrastructure.Migrations
{
    public partial class Kennel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zipcode_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Kennels",
                columns: table => new
                {
                    KennelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KennelName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KennelSmiley_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kennels", x => x.KennelId);
                    table.ForeignKey(
                        name: "FK_Kennels_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Protokols",
                columns: table => new
                {
                    ProtokolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KennelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protokols", x => x.ProtokolId);
                    table.ForeignKey(
                        name: "FK_Protokols_Kennels_KennelId",
                        column: x => x.KennelId,
                        principalTable: "Kennels",
                        principalColumn: "KennelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProtokolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubRaceId_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegNo_Value = table.Column<int>(type: "int", nullable: true),
                    PedigreeName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate_Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeathDate_Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender_Value = table.Column<bool>(type: "bit", nullable: true),
                    Color_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBreedable_Value = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_Protokols_ProtokolId",
                        column: x => x.ProtokolId,
                        principalTable: "Protokols",
                        principalColumn: "ProtokolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Litters",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LitterName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LitterBirthDate_Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChildAmount_Value = table.Column<int>(type: "int", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Litters", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Litters_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ProtokolId",
                table: "Animals",
                column: "ProtokolId");

            migrationBuilder.CreateIndex(
                name: "IX_Kennels_OwnerId",
                table: "Kennels",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Protokols_KennelId",
                table: "Protokols",
                column: "KennelId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Litters");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Protokols");

            migrationBuilder.DropTable(
                name: "Kennels");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
