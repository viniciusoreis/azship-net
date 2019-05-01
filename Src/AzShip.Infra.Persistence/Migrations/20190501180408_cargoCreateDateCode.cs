using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzShip.Infra.Persistence.Migrations
{
    public partial class cargoCreateDateCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Cargo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RefCode",
                table: "Cargo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Cargo");

            migrationBuilder.DropColumn(
                name: "RefCode",
                table: "Cargo");
        }
    }
}
