using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kennel.Infrastructure.Migrations
{
    public partial class Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Protokols_ProtokolId",
                table: "Animals");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProtokolId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Protokols_ProtokolId",
                table: "Animals",
                column: "ProtokolId",
                principalTable: "Protokols",
                principalColumn: "ProtokolId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Protokols_ProtokolId",
                table: "Animals");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProtokolId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Protokols_ProtokolId",
                table: "Animals",
                column: "ProtokolId",
                principalTable: "Protokols",
                principalColumn: "ProtokolId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
