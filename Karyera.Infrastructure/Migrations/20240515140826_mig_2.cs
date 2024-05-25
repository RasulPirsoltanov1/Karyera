using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karyera.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_MainCategory",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "MainCategory",
                table: "Categories",
                newName: "MainCategoryId1");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_MainCategory",
                table: "Categories",
                newName: "IX_Categories_MainCategoryId1");

            migrationBuilder.AddColumn<int>(
                name: "MainCategoryId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MainCategoryId",
                table: "Categories",
                column: "MainCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_MainCategoryId",
                table: "Categories",
                column: "MainCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_MainCategoryId1",
                table: "Categories",
                column: "MainCategoryId1",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_MainCategoryId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_MainCategoryId1",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MainCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MainCategoryId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "MainCategoryId1",
                table: "Categories",
                newName: "MainCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_MainCategoryId1",
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
    }
}
