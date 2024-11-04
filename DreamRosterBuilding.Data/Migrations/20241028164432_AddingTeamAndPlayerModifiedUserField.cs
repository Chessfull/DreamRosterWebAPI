using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamRosterBuilding.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingTeamAndPlayerModifiedUserField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModifiedUser",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedUser",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedUser",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ModifiedUser",
                table: "Players");
        }
    }
}
