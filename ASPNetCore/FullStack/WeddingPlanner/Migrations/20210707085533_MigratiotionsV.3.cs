using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingPlanner.Migrations
{
    public partial class MigratiotionsV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_PlannedByUserId",
                table: "Weddings");

            migrationBuilder.DropIndex(
                name: "IX_Weddings_PlannedByUserId",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "PlannedByUserId",
                table: "Weddings");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Weddings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_UserId",
                table: "Weddings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_UserId",
                table: "Weddings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_UserId",
                table: "Weddings");

            migrationBuilder.DropIndex(
                name: "IX_Weddings_UserId",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Weddings");

            migrationBuilder.AddColumn<int>(
                name: "PlannedByUserId",
                table: "Weddings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_PlannedByUserId",
                table: "Weddings",
                column: "PlannedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_PlannedByUserId",
                table: "Weddings",
                column: "PlannedByUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
