using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EthanCommunion.API.Migrations
{
    public partial class EthanCommunionDBChangedInfants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Infant",
                table: "Star");

            migrationBuilder.AddColumn<int>(
                name: "Infants",
                table: "Star",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Infants",
                table: "Star");

            migrationBuilder.AddColumn<int>(
                name: "Infant",
                table: "Star",
                nullable: false,
                defaultValue: 0);
        }
    }
}
