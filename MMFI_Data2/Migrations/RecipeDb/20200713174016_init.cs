using Microsoft.EntityFrameworkCore.Migrations;

namespace MMFI_Data.Migrations.RecipeDb
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeName = table.Column<string>(nullable: true),
                    RecipeTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                });

            migrationBuilder.CreateTable(
                name: "Ingridient",
                columns: table => new
                {
                    IngridientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngridientName = table.Column<string>(nullable: true),
                    RecipeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingridient", x => x.IngridientId);
                    table.ForeignKey(
                        name: "FK_Ingridient_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingridient_RecipeId",
                table: "Ingridient",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingridient");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
