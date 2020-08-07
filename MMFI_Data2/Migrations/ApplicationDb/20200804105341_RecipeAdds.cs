using Microsoft.EntityFrameworkCore.Migrations;

namespace MMFI_Data.Migrations.ApplicationDb
{
    public partial class RecipeAdds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipeCategory",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecipePortions",
                table: "Recipes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeCategory",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipePortions",
                table: "Recipes");
        }
    }
}
