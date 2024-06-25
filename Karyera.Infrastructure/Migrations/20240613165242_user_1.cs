using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karyera.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class user_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Resume",
                table: "AspNetUsers",
                newName: "ResumeUrl");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ResumeUrl",
                table: "AspNetUsers",
                newName: "Resume");
        }
    }
}
