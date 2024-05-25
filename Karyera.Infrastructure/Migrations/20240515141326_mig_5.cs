using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karyera.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_MainCategoryId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "MainCategoryId",
                table: "Categories",
                newName: "MainCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_MainCategoryId",
                table: "Categories",
                newName: "IX_Categories_MainCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_MainCategory",
                table: "Categories",
                column: "MainCategory",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_MainCategory",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "MainCategory",
                table: "Categories",
                newName: "MainCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_MainCategory",
                table: "Categories",
                newName: "IX_Categories_MainCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_MainCategoryId",
                table: "Categories",
                column: "MainCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
