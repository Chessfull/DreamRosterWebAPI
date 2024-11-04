using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DreamRosterBuilding.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Icons_IconId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_IconId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "IconId",
                table: "Teams");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Flags",
                columns: new[] { "Id", "CreatedDate", "ImagePath", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(2241), "images/flags/Flag_of_Turkey.png", false, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(2248), "Turkiye" },
                    { 2, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(2251), "images/flags/Flag_of_Spain.png", false, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(2251), "Spain" }
                });

            migrationBuilder.InsertData(
                table: "Icons",
                columns: new[] { "Id", "CreatedDate", "HairColor", "ImagePath", "IsDeleted", "ModifiedDate", "Name", "Skin", "Tattoo" },
                values: new object[] { 1, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(3584), 0, "images/icons/icon-default.png", false, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(3587), "BlackHairMediumSkinNoTattoo", 1, null });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[] { 1, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(6716), false, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(6719), "GK" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[] { 1, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(7770), false, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(7772), "Keeping" });

            migrationBuilder.InsertData(
                table: "Nations",
                columns: new[] { "Id", "CreatedDate", "FlagId", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(7942), 1, false, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(7945), "Türkiye" },
                    { 2, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(7947), 2, false, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(7948), "Spain" }
                });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "ModifiedDate", "Name", "NationId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(5431), false, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(5434), "Süper Lig", 1 },
                    { 2, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(5436), false, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(5436), "LaLiga", 2 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "Image", "IsDeleted", "LeagueId", "ModifiedDate", "ModifiedUser", "Name", "NationId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8939), "admin", "images/teams/Fenerbahce.png", false, 1, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8942), "admin", "Fenerbahçe", 1 },
                    { 2, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8946), "admin", "images/teams/Galatasaray.png", false, 1, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8947), "admin", "Galatasaray", 1 },
                    { 3, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8948), "admin", "images/teams/Real_Madrid.png", false, 2, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8949), "admin", "Real Madrid", 2 },
                    { 4, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8951), "admin", "images/teams/Barcelona.png", false, 2, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8951), "admin", "Barcelona", 2 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "CreatedUser", "HairColor", "IconId", "IsDeleted", "LeagueId", "ModifiedDate", "ModifiedUser", "Name", "NationId", "Skin", "Tattoo", "TeamId" },
                values: new object[] { 1, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(9916), new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(9922), "admin", 0, 1, false, 1, new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(9922), "admin", "Mert Topcu", 1, 1, null, 1 });

            migrationBuilder.InsertData(
                table: "PlayerPositions",
                columns: new[] { "PlayerId", "PositionId", "CreatedDate", "IsDeleted", "ModifiedDate" },
                values: new object[] { 1, 1, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(1417), false, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(1420) });

            migrationBuilder.InsertData(
                table: "PlayerSkills",
                columns: new[] { "PlayerId", "SkillId", "CreatedDate", "IsDeleted", "ModifiedDate" },
                values: new object[] { 1, 1, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(4370), false, new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(4373) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumns: new[] { "PlayerId", "PositionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PlayerSkills",
                keyColumns: new[] { "PlayerId", "SkillId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Icons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "IconId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_IconId",
                table: "Teams",
                column: "IconId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Icons_IconId",
                table: "Teams",
                column: "IconId",
                principalTable: "Icons",
                principalColumn: "Id");
        }
    }
}
