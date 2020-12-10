using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoImagerApi.Migrations
{
    public partial class NewFollowSystemThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follower_UserProfiles_FollowedById",
                table: "Follower");

            migrationBuilder.DropForeignKey(
                name: "FK_Follower_UserProfiles_UserId",
                table: "Follower");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follower",
                table: "Follower");

            migrationBuilder.RenameTable(
                name: "Follower",
                newName: "Followers");

            migrationBuilder.RenameIndex(
                name: "IX_Follower_UserId",
                table: "Followers",
                newName: "IX_Followers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Follower_FollowedById",
                table: "Followers",
                newName: "IX_Followers_FollowedById");

            migrationBuilder.AddColumn<int>(
                name: "FollowerType",
                table: "Followers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followers",
                table: "Followers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_UserProfiles_FollowedById",
                table: "Followers",
                column: "FollowedById",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_UserProfiles_UserId",
                table: "Followers",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_UserProfiles_FollowedById",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followers_UserProfiles_UserId",
                table: "Followers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Followers",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "FollowerType",
                table: "Followers");

            migrationBuilder.RenameTable(
                name: "Followers",
                newName: "Follower");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_UserId",
                table: "Follower",
                newName: "IX_Follower_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_FollowedById",
                table: "Follower",
                newName: "IX_Follower_FollowedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follower",
                table: "Follower",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follower_UserProfiles_FollowedById",
                table: "Follower",
                column: "FollowedById",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Follower_UserProfiles_UserId",
                table: "Follower",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
