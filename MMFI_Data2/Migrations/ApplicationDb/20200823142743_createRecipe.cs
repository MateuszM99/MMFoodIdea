using Microsoft.EntityFrameworkCore.Migrations;

namespace MMFI_Data.Migrations.ApplicationDb
{
    public partial class createRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngridients");

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "Ingridients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Ingridients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingridients_RecipeId",
                table: "Ingridients",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingridients_Recipes_RecipeId",
                table: "Ingridients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingridients_Recipes_RecipeId",
                table: "Ingridients");

            migrationBuilder.DropIndex(
                name: "IX_Ingridients_RecipeId",
                table: "Ingridients");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Ingridients");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Ingridients");

            migrationBuilder.CreateTable(
                name: "RecipeIngridients",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    IngridientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngridients", x => new { x.RecipeId, x.IngridientId });
                    table.ForeignKey(
                        name: "FK_RecipeIngridients_Ingridients_IngridientId",
                        column: x => x.IngridientId,
                        principalTable: "Ingridients",
                        principalColumn: "IngridientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngridients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngridients_IngridientId",
                table: "RecipeIngridients",
                column: "IngridientId");
        }
    }
}
