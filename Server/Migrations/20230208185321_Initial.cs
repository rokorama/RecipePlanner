using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipePlanner.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vegetarian = table.Column<bool>(type: "bit", nullable: false),
                    Vegan = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Measurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preparation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Optional = table.Column<bool>(type: "bit", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeStep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Optional = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeStep_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "Id", "DateCreated", "Description", "Name", "Source", "UploadedBy", "Vegan", "Vegetarian" },
                values: new object[] { new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651"), new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Local), "A simple dish made only with leftover rice and an egg. Feel free to add any other ingredients like vegetables or meat.", "Egg fried rice", null, new Guid("9841dbcf-02a4-4be6-9545-35aff7db9c7b"), false, true });

            migrationBuilder.InsertData(
                table: "RecipeIngredient",
                columns: new[] { "Id", "Measurement", "Name", "Optional", "Preparation", "Quantity", "RecipeId" },
                values: new object[,]
                {
                    { new Guid("1094e6b3-0ead-4783-a647-ea85a1ce7ceb"), "handful", "Frozen green peas", true, null, 2.0, null },
                    { new Guid("4516d7ed-0926-418f-9df7-a1a2f1855999"), "clove", "Garlic", false, "minced", 1.0, null },
                    { new Guid("68698fb1-da0e-4058-9295-4b3d949e55e9"), "cup", "Rice", false, "cooked", 1.0, null },
                    { new Guid("97065633-14b7-457f-8f2e-ea31d2f78d8d"), "cup", "Egg", false, null, 1.0, null },
                    { new Guid("d365c0be-30ca-4a23-b876-b9e51da0b29e"), "tbsp", "Soy sauce", false, null, 1.0, null }
                });

            migrationBuilder.InsertData(
                table: "RecipeStep",
                columns: new[] { "Id", "Content", "Index", "Optional", "RecipeId" },
                values: new object[,]
                {
                    { new Guid("1a8d836e-db09-4a2c-8d1d-361a6ef73dda"), "Add in any additional ingredients such as frozen peas and let them heat through", 5, true, new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651") },
                    { new Guid("43e87089-2be8-48c2-bb63-48512a778b77"), "Dump in the rice and start breaking the clumps into individual grains", 3, false, new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651") },
                    { new Guid("637bf9fc-3b13-4baf-b5d7-5ba8f9943c30"), "Crack in the egg and scramble vigorously to break it up into small chunks", 1, false, new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651") },
                    { new Guid("75325287-47b8-42d1-ad74-11f0b614522c"), "Heat a pan with some oil on medium-high heat", 0, false, new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651") },
                    { new Guid("beef6720-d0c3-4bc0-9ab5-626bed117797"), "Once the rice is heated through and slightly toasty, add the soy sauce and mix throughout", 4, false, new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651") },
                    { new Guid("de2b4f9b-681d-40c5-8d31-951e527c5fdf"), "Add the garlic and cook until fragrant", 2, false, new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651") },
                    { new Guid("fa1c36e4-d7c7-43aa-af82-2e5584662f5f"), "Add in any additional ingredients such as frozen peas and let them heat through", 5, true, new Guid("2a3d6c16-98f9-47bf-ad3a-5ed26ec20651") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipeId",
                table: "RecipeIngredient",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeStep_RecipeId",
                table: "RecipeStep",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredient");

            migrationBuilder.DropTable(
                name: "RecipeStep");

            migrationBuilder.DropTable(
                name: "Recipe");
        }
    }
}
