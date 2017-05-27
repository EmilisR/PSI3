using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Festofilas.Data.Migrations
{
    public partial class userfestival : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IX_Festivals_UserFestivalFestivalId_UserFestivalUserId",
                table: "Festivals");

            migrationBuilder.DropColumn(
                name: "UserFestivalFestivalId",
                table: "Festivals");

            migrationBuilder.DropColumn(
                name: "UserFestivalUserId",
                table: "Festivals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFestivals",
                table: "UserFestival",
                columns: new[] { "FestivalId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserFestivals_FestivalId",
                table: "UserFestival",
                column: "FestivalId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFestivals_Festivals_FestivalId",
                table: "UserFestival",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFestivals_AspNetUsers_UserId",
                table: "UserFestival",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_UserFestival_UserId",
                table: "UserFestival",
                newName: "IX_UserFestivals_UserId");

            migrationBuilder.RenameTable(
                name: "UserFestival",
                newName: "UserFestivals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFestivals_Festivals_FestivalId",
                table: "UserFestivals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFestivals_AspNetUsers_UserId",
                table: "UserFestivals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFestivals",
                table: "UserFestivals");

            migrationBuilder.DropIndex(
                name: "IX_UserFestivals_FestivalId",
                table: "UserFestivals");

            migrationBuilder.AddColumn<int>(
                name: "UserFestivalFestivalId",
                table: "Festivals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserFestivalUserId",
                table: "Festivals",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFestival",
                table: "UserFestivals",
                columns: new[] { "FestivalId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Festivals_UserFestivalFestivalId_UserFestivalUserId",
                table: "Festivals",
                columns: new[] { "UserFestivalFestivalId", "UserFestivalUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Festivals_UserFestival_UserFestivalFestivalId_UserFestivalUserId",
                table: "Festivals",
                columns: new[] { "UserFestivalFestivalId", "UserFestivalUserId" },
                principalTable: "UserFestivals",
                principalColumns: new[] { "FestivalId", "UserId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFestival_AspNetUsers_UserId",
                table: "UserFestivals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_UserFestivals_UserId",
                table: "UserFestivals",
                newName: "IX_UserFestival_UserId");

            migrationBuilder.RenameTable(
                name: "UserFestivals",
                newName: "UserFestival");
        }
    }
}
