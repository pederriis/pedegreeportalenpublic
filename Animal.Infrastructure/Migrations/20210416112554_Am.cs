using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Infrastructure.Migrations
{
    public partial class Am : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Humans",
                columns: table => new
                {
                    HumanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humans", x => x.HumanId);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    RaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RaceName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.RaceId);
                });

            migrationBuilder.CreateTable(
                name: "Litters",
                columns: table => new
                {
                    LitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BreedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LitterBirthDate_Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MatingDate_Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Litters", x => x.LitterId);
                    table.ForeignKey(
                        name: "FK_Litters_Humans_BreedById",
                        column: x => x.BreedById,
                        principalTable: "Humans",
                        principalColumn: "HumanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubRaces",
                columns: table => new
                {
                    SubRaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubRaceName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRaces", x => x.SubRaceId);
                    table.ForeignKey(
                        name: "FK_SubRaces_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "RaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubRaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegNo_Value = table.Column<int>(type: "int", nullable: true),
                    PedigreeName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate_Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeathDate_Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender_Value = table.Column<bool>(type: "bit", nullable: true),
                    Color_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightInKg_Value = table.Column<double>(type: "float", nullable: true),
                    IsBreedable_Value = table.Column<bool>(type: "bit", nullable: true),
                    ProfileText_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_Humans_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Humans",
                        principalColumn: "HumanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_SubRaces_SubRaceId",
                        column: x => x.SubRaceId,
                        principalTable: "SubRaces",
                        principalColumn: "SubRaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimalLitters",
                columns: table => new
                {
                    AnimalLitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LitterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalLitters", x => x.AnimalLitterId);
                    table.ForeignKey(
                        name: "FK_AnimalLitters_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimalLitters_Litters_LitterId",
                        column: x => x.LitterId,
                        principalTable: "Litters",
                        principalColumn: "LitterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExhibitionTitles",
                columns: table => new
                {
                    ExhibitionTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Value = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionTitles", x => x.ExhibitionTitleId);
                    table.ForeignKey(
                        name: "FK_ExhibitionTitles_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthRecords",
                columns: table => new
                {
                    HealthRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRecords", x => x.HealthRecordId);
                    table.ForeignKey(
                        name: "FK_HealthRecords_Animals_HealthRecordId",
                        column: x => x.HealthRecordId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalLitters_AnimalId",
                table: "AnimalLitters",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalLitters_LitterId",
                table: "AnimalLitters",
                column: "LitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_OwnerId",
                table: "Animals",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SubRaceId",
                table: "Animals",
                column: "SubRaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionTitles_AnimalId",
                table: "ExhibitionTitles",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Litters_BreedById",
                table: "Litters",
                column: "BreedById");

            migrationBuilder.CreateIndex(
                name: "IX_SubRaces_RaceId",
                table: "SubRaces",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalLitters");

            migrationBuilder.DropTable(
                name: "ExhibitionTitles");

            migrationBuilder.DropTable(
                name: "HealthRecords");

            migrationBuilder.DropTable(
                name: "Litters");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Humans");

            migrationBuilder.DropTable(
                name: "SubRaces");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
