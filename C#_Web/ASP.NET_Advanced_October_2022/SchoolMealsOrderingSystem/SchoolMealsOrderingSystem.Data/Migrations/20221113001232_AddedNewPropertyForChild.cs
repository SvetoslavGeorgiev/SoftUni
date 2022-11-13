using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMealsOrderingSystem.Data.Migrations
{
    public partial class AddedNewPropertyForChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_SchoolUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SchoolUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SchoolUserId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "YearInSchool",
                table: "Children",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearInSchool",
                table: "Children");

            migrationBuilder.AddColumn<string>(
                name: "SchoolUserId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SchoolUserId",
                table: "AspNetUsers",
                column: "SchoolUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_SchoolUserId",
                table: "AspNetUsers",
                column: "SchoolUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
