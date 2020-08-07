using Microsoft.EntityFrameworkCore.Migrations;

namespace MMFI_Data.Migrations.ApplicationDb
{
    public partial class ingridients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingridient_Recipes_RecipeId",
                table: "Ingridient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingridient",
                table: "Ingridient");

            migrationBuilder.DropIndex(
                name: "IX_Ingridient_RecipeId",
                table: "Ingridient");

            migrationBuilder.DropColumn(
                name: "IngridientName",
                table: "Ingridient");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Ingridient");

            migrationBuilder.RenameTable(
                name: "Ingridient",
                newName: "Ingridients");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ingridients",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingridients",
                table: "Ingridients",
                column: "IngridientId");

            migrationBuilder.CreateTable(
                name: "RecipeIngridients",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    IngridientId = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngridients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingridients",
                table: "Ingridients");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ingridients");

            migrationBuilder.RenameTable(
                name: "Ingridients",
                newName: "Ingridient");

            migrationBuilder.AddColumn<string>(
                name: "IngridientName",
                table: "Ingridient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Ingridient",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingridient",
                table: "Ingridient",
                column: "IngridientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingridient_RecipeId",
                table: "Ingridient",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingridient_Recipes_RecipeId",
                table: "Ingridient",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
