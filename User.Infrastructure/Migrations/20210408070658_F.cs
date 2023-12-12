using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace User.Infrastructure.Migrations
{
    public partial class F : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zipcode_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileText_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBreeder_Value = table.Column<bool>(type: "bit", nullable: true),
                    IsClubRepresentative_Value = table.Column<bool>(type: "bit", nullable: true),
                    IsOwner_Value = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted_Value = table.Column<bool>(type: "bit", nullable: true),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalName_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Value = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_UserId",
                table: "Animals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
