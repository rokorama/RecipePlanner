using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipePlanner.Server.Migrations
{
    /// <inheritdoc />
    public partial class AdjustUserRecipeconfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipes_Users_UserId",
                table: "UserRecipes");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651"),
                column: "DateCreated",
                value: new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9841dbcf-02a4-4be6-9545-35aff7db9c7b"),
                column: "DateCreated",
                value: new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipes_Users_UserId",
                table: "UserRecipes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipes_Users_UserId",
                table: "UserRecipes");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651"),
                column: "DateCreated",
                value: new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9841dbcf-02a4-4be6-9545-35aff7db9c7b"),
                column: "DateCreated",
                value: new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipes_Users_UserId",
                table: "UserRecipes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
