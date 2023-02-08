using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipePlanner.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixRecipeIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.DeleteData(
                table: "RecipeSteps",
                keyColumn: "Id",
                keyValue: new Guid("1a8d836e-db09-4a2c-8d1d-361a6ef73dda"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "RecipeIngredients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: new Guid("1094e6b3-0ead-4783-a647-ea85a1ce7ceb"),
                column: "RecipeId",
                value: new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651"));

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: new Guid("4516d7ed-0926-418f-9df7-a1a2f1855999"),
                column: "RecipeId",
                value: new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651"));

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: new Guid("68698fb1-da0e-4058-9295-4b3d949e55e9"),
                column: "RecipeId",
                value: new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651"));

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: new Guid("97065633-14b7-457f-8f2e-ea31d2f78d8d"),
                column: "RecipeId",
                value: new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651"));

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: new Guid("d365c0be-30ca-4a23-b876-b9e51da0b29e"),
                column: "RecipeId",
                value: new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651"));

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "RecipeIngredients",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: new Guid("1094e6b3-0ead-4783-a647-ea85a1ce7ceb"),
                column: "RecipeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: new Guid("4516d7ed-0926-418f-9df7-a1a2f1855999"),
                column: "RecipeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: new Guid("68698fb1-da0e-4058-9295-4b3d949e55e9"),
                column: "RecipeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: new Guid("97065633-14b7-457f-8f2e-ea31d2f78d8d"),
                column: "RecipeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: new Guid("d365c0be-30ca-4a23-b876-b9e51da0b29e"),
                column: "RecipeId",
                value: null);

            migrationBuilder.InsertData(
                table: "RecipeSteps",
                columns: new[] { "Id", "Content", "Index", "Optional", "RecipeId" },
                values: new object[] { new Guid("1a8d836e-db09-4a2c-8d1d-361a6ef73dda"), "Add in any additional ingredients such as frozen peas and let them heat through", 5, true, new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651") });

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
