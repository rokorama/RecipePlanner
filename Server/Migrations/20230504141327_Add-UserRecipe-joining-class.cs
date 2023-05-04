using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipePlanner.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRecipejoiningclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadedBy",
                table: "Recipes",
                newName: "UploadedById");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRecipes",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRecipes", x => new { x.UserId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_UserRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRecipes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651"),
                columns: new[] { "DateCreated", "UploadedById" },
                values: new object[] { new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Local), new Guid("9841dbcf-02a4-4be6-9545-35aff7db9c7b") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "Email", "Name", "Password", "Role" },
                values: new object[] { new Guid("9841dbcf-02a4-4be6-9545-35aff7db9c7b"), new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Local), "asd@asd.asd", "User", "", "user" });

            migrationBuilder.InsertData(
                table: "UserRecipes",
                columns: new[] { "RecipeId", "UserId" },
                values: new object[] { new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651"), new Guid("9841dbcf-02a4-4be6-9545-35aff7db9c7b") });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UploadedById",
                table: "Recipes",
                column: "UploadedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRecipes_RecipeId",
                table: "UserRecipes",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_UploadedById",
                table: "Recipes",
                column: "UploadedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_UploadedById",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "UserRecipes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_UploadedById",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "UploadedById",
                table: "Recipes",
                newName: "UploadedBy");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651"),
                columns: new[] { "DateCreated", "UploadedBy" },
                values: new object[] { new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Local), new Guid("9841dbcf-02a4-4be6-9545-35aff7db9c7b") });
        }
    }
}
