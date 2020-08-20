using Microsoft.EntityFrameworkCore.Migrations;

namespace MMFI_Data.Migrations.ApplicationDb
{
    public partial class RecipeLikes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLike_AspNetUsers_AppUserId",
                table: "RecipeLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeLike",
                table: "RecipeLike");

            migrationBuilder.RenameTable(
                name: "RecipeLike",
                newName: "RecipeLikes");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeLike_AppUserId",
                table: "RecipeLikes",
                newName: "IX_RecipeLikes_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeLikes",
                table: "RecipeLikes",
                column: "RecipeLikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLikes_AspNetUsers_AppUserId",
                table: "RecipeLikes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLikes_AspNetUsers_AppUserId",
                table: "RecipeLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeLikes",
                table: "RecipeLikes");

            migrationBuilder.RenameTable(
                name: "RecipeLikes",
                newName: "RecipeLike");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeLikes_AppUserId",
                table: "RecipeLike",
                newName: "IX_RecipeLike_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeLike",
                table: "RecipeLike",
                column: "RecipeLikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLike_AspNetUsers_AppUserId",
                table: "RecipeLike",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
