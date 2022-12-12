using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMealsOrderingSystem.Data.Migrations
{
    public partial class AddedMealsAndMenuEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desserts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Ingredients = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Allergens = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desserts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainDishes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Ingredients = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Allergens = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainDishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Soups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Allergens = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyMenus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MainDishId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DessertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChildId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyMenus_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyMenus_Desserts_DessertId",
                        column: x => x.DessertId,
                        principalTable: "Desserts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyMenus_MainDishes_MainDishId",
                        column: x => x.MainDishId,
                        principalTable: "MainDishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyMenus_Soups_SoupId",
                        column: x => x.SoupId,
                        principalTable: "Soups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyMenus_ChildId",
                table: "DailyMenus",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyMenus_DessertId",
                table: "DailyMenus",
                column: "DessertId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyMenus_MainDishId",
                table: "DailyMenus",
                column: "MainDishId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyMenus_SoupId",
                table: "DailyMenus",
                column: "SoupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyMenus");

            migrationBuilder.DropTable(
                name: "Desserts");

            migrationBuilder.DropTable(
                name: "MainDishes");

            migrationBuilder.DropTable(
                name: "Soups");
        }
    }
}
