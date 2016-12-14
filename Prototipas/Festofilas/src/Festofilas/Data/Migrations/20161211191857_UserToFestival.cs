using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Festofilas.Data.Migrations
{
    public partial class UserToFestival : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WritersId",
                table: "Articles",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmissionTime",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WritersId",
                table: "Articles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmissionTime",
                table: "Articles",
                nullable: false);
        }
    }
}
