using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMealsOrderingSystem.Data.Migrations
{
    public partial class AddedSchoolUserRelationToMeals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SchoolUserId",
                table: "Soups",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolUserId",
                table: "MainDishes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolUserId",
                table: "Desserts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Soups_SchoolUserId",
                table: "Soups",
                column: "SchoolUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MainDishes_SchoolUserId",
                table: "MainDishes",
                column: "SchoolUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Desserts_SchoolUserId",
                table: "Desserts",
                column: "SchoolUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desserts_AspNetUsers_SchoolUserId",
                table: "Desserts",
                column: "SchoolUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainDishes_AspNetUsers_SchoolUserId",
                table: "MainDishes",
                column: "SchoolUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Soups_AspNetUsers_SchoolUserId",
                table: "Soups",
                column: "SchoolUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desserts_AspNetUsers_SchoolUserId",
                table: "Desserts");

            migrationBuilder.DropForeignKey(
                name: "FK_MainDishes_AspNetUsers_SchoolUserId",
                table: "MainDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Soups_AspNetUsers_SchoolUserId",
                table: "Soups");

            migrationBuilder.DropIndex(
                name: "IX_Soups_SchoolUserId",
                table: "Soups");

            migrationBuilder.DropIndex(
                name: "IX_MainDishes_SchoolUserId",
                table: "MainDishes");

            migrationBuilder.DropIndex(
                name: "IX_Desserts_SchoolUserId",
                table: "Desserts");

            migrationBuilder.DropColumn(
                name: "SchoolUserId",
                table: "Soups");

            migrationBuilder.DropColumn(
                name: "SchoolUserId",
                table: "MainDishes");

            migrationBuilder.DropColumn(
                name: "SchoolUserId",
                table: "Desserts");
        }
    }
}
