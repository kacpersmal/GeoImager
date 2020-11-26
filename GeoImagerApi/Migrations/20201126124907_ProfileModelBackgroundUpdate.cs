using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoImagerApi.Migrations
{
    public partial class ProfileModelBackgroundUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePictureName",
                table: "UserProfiles",
                newName: "ProfilePicturePath");

            migrationBuilder.AddColumn<string>(
                name: "ProfileBackgroundPath",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileBackgroundPath",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "ProfilePicturePath",
                table: "UserProfiles",
                newName: "ProfilePictureName");
        }
    }
}
