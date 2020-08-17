using Microsoft.EntityFrameworkCore.Migrations;

namespace MMFI_Data.Migrations.ApplicationDb
{
    public partial class profilI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_AppUserId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AppUserId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "ProfileImageImageId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileImageImageId",
                table: "AspNetUsers",
                column: "ProfileImageImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ProfileImageImageId",
                table: "AspNetUsers",
                column: "ProfileImageImageId",
                principalTable: "Images",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ProfileImageImageId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileImageImageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileImageImageId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AppUserId",
                table: "Images",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_AppUserId",
                table: "Images",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
