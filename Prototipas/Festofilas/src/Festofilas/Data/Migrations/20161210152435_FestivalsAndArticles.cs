using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Festofilas.Data.Migrations
{
    public partial class FestivalsAndArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image64 = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SubmissionTime = table.Column<DateTime>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Festivals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactsJson = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Genre = table.Column<int>(nullable: false),
                    Highest
                    = table.Column<int>(nullable: false),
                    Image64 = table.Column<string>(nullable: true),
                    LocationJson = table.Column<string>(nullable: true),
                    LowestPrice = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    TicketWebsite = table.Column<string>(nullable: true),
                    Webpage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleFestival",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false),
                    FestivalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleFestival", x => new { x.ArticleId, x.FestivalId });
                    table.ForeignKey(
                        name: "FK_ArticleFestival_Festivals_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleFestival_Articles_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleFestival_ArticleId",
                table: "ArticleFestival",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleFestival_FestivalId",
                table: "ArticleFestival",
                column: "FestivalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleFestival");

            migrationBuilder.DropTable(
                name: "Festivals");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
