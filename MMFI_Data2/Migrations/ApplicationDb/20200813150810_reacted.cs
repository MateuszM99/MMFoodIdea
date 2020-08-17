using Microsoft.EntityFrameworkCore.Migrations;

namespace MMFI_Data.Migrations.ApplicationDb
{
    public partial class reacted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reacted",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reacted",
                table: "Comments");
        }
    }
}
