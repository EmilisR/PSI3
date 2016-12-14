using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Festofilas.Data.Migrations
{
    public partial class nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LowestPrice",
                table: "Festivals",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HighestPrice",
                table: "Festivals",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Genre",
                table: "Festivals",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Festivals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LowestPrice",
                table: "Festivals",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HighestPrice",
                table: "Festivals",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Genre",
                table: "Festivals",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Festivals",
                nullable: true);
        }
    }
}
