using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingPlanner.Migrations
{
    public partial class MigratiotionsV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Weddings",
                columns: table => new
                {
                    WeddingId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WedderOne = table.Column<string>(nullable: false),
                    WedderTow = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    PlannedByUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weddings", x => x.WeddingId);
                    table.ForeignKey(
                        name: "FK_Weddings_Users_PlannedByUserId",
                        column: x => x.PlannedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserWeddings",
                columns: table => new
                {
                    UserWeddingId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    WeddingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWeddings", x => x.UserWeddingId);
                    table.ForeignKey(
                        name: "FK_UserWeddings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWeddings_Weddings_WeddingId",
                        column: x => x.WeddingId,
                        principalTable: "Weddings",
                        principalColumn: "WeddingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserWeddings_UserId",
                table: "UserWeddings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWeddings_WeddingId",
                table: "UserWeddings",
                column: "WeddingId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_PlannedByUserId",
                table: "Weddings",
                column: "PlannedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserWeddings");

            migrationBuilder.DropTable(
                name: "Weddings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
