using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMealsOrderingSystem.Data.Migrations
{
    public partial class FlagForIsSelectedIsAddedToAllMeals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Soups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "MainDishes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Desserts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Soups");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "MainDishes");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Desserts");
        }
    }
}
