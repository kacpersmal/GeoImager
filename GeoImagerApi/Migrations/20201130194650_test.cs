using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoImagerApi.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserImagePostModel_UserPostModel_UserPostModelId",
                table: "UserImagePostModel");

            migrationBuilder.RenameColumn(
                name: "UserPostModelId",
                table: "UserImagePostModel",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserImagePostModel_UserPostModelId",
                table: "UserImagePostModel",
                newName: "IX_UserImagePostModel_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserImagePostModel_UserPostModel_OwnerId",
                table: "UserImagePostModel",
                column: "OwnerId",
                principalTable: "UserPostModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserImagePostModel_UserPostModel_OwnerId",
                table: "UserImagePostModel");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "UserImagePostModel",
                newName: "UserPostModelId");

            migrationBuilder.RenameIndex(
                name: "IX_UserImagePostModel_OwnerId",
                table: "UserImagePostModel",
                newName: "IX_UserImagePostModel_UserPostModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserImagePostModel_UserPostModel_UserPostModelId",
                table: "UserImagePostModel",
                column: "UserPostModelId",
                principalTable: "UserPostModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
