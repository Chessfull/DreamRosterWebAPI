﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamRosterBuilding.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingTeamAndPlayerCreatedUserField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUser",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CreatedUser",
                table: "Players");
        }
    }
}
