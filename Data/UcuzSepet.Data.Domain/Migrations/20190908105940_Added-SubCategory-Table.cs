using Microsoft.EntityFrameworkCore.Migrations;

namespace UcuzSepet.Data.Domain.Migrations
{
    public partial class AddedSubCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_RootCategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_RootCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "RootCategoryId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RootCategoryId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RootCategoryId",
                table: "Categories",
                column: "RootCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_RootCategoryId",
                table: "Categories",
                column: "RootCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
