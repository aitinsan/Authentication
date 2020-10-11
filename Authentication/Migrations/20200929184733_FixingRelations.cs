using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Authentication.Migrations
{
    public partial class FixingRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_MealCategories_CategoryId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_CategoryId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "MealCategory",
                table: "Meals");

            migrationBuilder.AddColumn<Guid>(
                name: "MealCategoryId",
                table: "Meals",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealCategoryId",
                table: "Meals",
                column: "MealCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_MealCategories_MealCategoryId",
                table: "Meals",
                column: "MealCategoryId",
                principalTable: "MealCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_MealCategories_MealCategoryId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_MealCategoryId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "MealCategoryId",
                table: "Meals");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Meals",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MealCategory",
                table: "Meals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Meals_CategoryId",
                table: "Meals",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_MealCategories_CategoryId",
                table: "Meals",
                column: "CategoryId",
                principalTable: "MealCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
