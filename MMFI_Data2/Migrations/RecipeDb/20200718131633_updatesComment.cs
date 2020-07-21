using Microsoft.EntityFrameworkCore.Migrations;

namespace MMFI_Data.Migrations.RecipeDb
{
    public partial class updatesComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Comments",
                newName: "Text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Comments",
                newName: "Body");
        }
    }
}
