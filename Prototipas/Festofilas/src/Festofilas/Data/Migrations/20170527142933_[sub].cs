using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Festofilas.Data.Migrations
{
    public partial class sub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFestival",
                table: "UserFestival");

            /*migrationBuilder.AddColumn<int>(
                name: "NumberOfVotes",
                table: "Festivals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalScore",
                table: "Festivals",
                nullable: false,
                defaultValue: 0.0);*/

            migrationBuilder.AddColumn<int>(
                name: "UserFestivalFestivalId",
                table: "Festivals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserFestivalUserId",
                table: "Festivals",
                nullable: true);

            /*migrationBuilder.AddColumn<string>(
                name: "WidgetCode",
                table: "Festivals",
                nullable: true);*/

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserFestival",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFestival",
                table: "UserFestival",
                columns: new[] { "FestivalId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserFestival_UserId",
                table: "UserFestival",
                column: "UserId");

            migrationBuilder.AlterColumn<double>(
                name: "LowestPrice",
                table: "Festivals",
                nullable: false);

            migrationBuilder.AlterColumn<double>(
                name: "HighestPrice",
                table: "Festivals",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Festivals_UserFestivalFestivalId_UserFestivalUserId",
                table: "Festivals",
                columns: new[] { "UserFestivalFestivalId", "UserFestivalUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Festivals_UserFestival_UserFestivalFestivalId_UserFestivalUserId",
                table: "Festivals",
                columns: new[] { "UserFestivalFestivalId", "UserFestivalUserId" },
                principalTable: "UserFestival",
                principalColumns: new[] { "FestivalId", "UserId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFestival_AspNetUsers_UserId",
                table: "UserFestival",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Festivals_UserFestival_UserFestivalFestivalId_UserFestivalUserId",
                table: "Festivals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFestival_AspNetUsers_UserId",
                table: "UserFestival");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFestival",
                table: "UserFestival");

            migrationBuilder.DropIndex(
                name: "IX_UserFestival_UserId",
                table: "UserFestival");

            migrationBuilder.DropIndex(
                name: "IX_Festivals_UserFestivalFestivalId_UserFestivalUserId",
                table: "Festivals");

            migrationBuilder.DropColumn(
                name: "NumberOfVotes",
                table: "Festivals");

            migrationBuilder.DropColumn(
                name: "TotalScore",
                table: "Festivals");

            migrationBuilder.DropColumn(
                name: "UserFestivalFestivalId",
                table: "Festivals");

            migrationBuilder.DropColumn(
                name: "UserFestivalUserId",
                table: "Festivals");

            migrationBuilder.DropColumn(
                name: "WidgetCode",
                table: "Festivals");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserFestival",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFestival",
                table: "UserFestival",
                column: "FestivalId");

            migrationBuilder.AlterColumn<int>(
                name: "LowestPrice",
                table: "Festivals",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HighestPrice",
                table: "Festivals",
                nullable: true);
        }
    }
}
