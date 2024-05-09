using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karyera.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixedRelatonshib : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_EducationInfos_EducationId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ExperienceInfos_ExperienceId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EducationId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ExperienceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EducationId1",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "ExperienceInfos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceInfos_AppUserId",
                table: "ExperienceInfos",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationInfos_AppUserId",
                table: "EducationInfos",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationInfos_AspNetUsers_AppUserId",
                table: "EducationInfos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceInfos_AspNetUsers_AppUserId",
                table: "ExperienceInfos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationInfos_AspNetUsers_AppUserId",
                table: "EducationInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceInfos_AspNetUsers_AppUserId",
                table: "ExperienceInfos");

            migrationBuilder.DropIndex(
                name: "IX_ExperienceInfos_AppUserId",
                table: "ExperienceInfos");

            migrationBuilder.DropIndex(
                name: "IX_EducationInfos_AppUserId",
                table: "EducationInfos");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ExperienceInfos");

            migrationBuilder.AddColumn<int>(
                name: "EducationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EducationId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EducationId1",
                table: "AspNetUsers",
                column: "EducationId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ExperienceId",
                table: "AspNetUsers",
                column: "ExperienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_EducationInfos_EducationId1",
                table: "AspNetUsers",
                column: "EducationId1",
                principalTable: "EducationInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ExperienceInfos_ExperienceId",
                table: "AspNetUsers",
                column: "ExperienceId",
                principalTable: "ExperienceInfos",
                principalColumn: "Id");
        }
    }
}
