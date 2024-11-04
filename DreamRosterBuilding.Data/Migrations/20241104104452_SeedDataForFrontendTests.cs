using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DreamRosterBuilding.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForFrontendTests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Positions",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.UpdateData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(577), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(586) });

            migrationBuilder.UpdateData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(588), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(589) });

            migrationBuilder.UpdateData(
                table: "Icons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(1817), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(1819) });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(3641), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(3643) });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(3645), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(3646) });

            migrationBuilder.UpdateData(
                table: "Nations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(6206), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(6209) });

            migrationBuilder.UpdateData(
                table: "Nations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(6211), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(6212) });

            migrationBuilder.UpdateData(
                table: "PlayerPositions",
                keyColumns: new[] { "PlayerId", "PositionId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9824), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9827) });

            migrationBuilder.UpdateData(
                table: "PlayerSkills",
                keyColumns: new[] { "PlayerId", "SkillId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(2598), new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(2601) });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedDate", "LeagueId", "ModifiedDate", "NationId", "TeamId" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8192), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8198), 2, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8198), 2, 4 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "CreatedDate", "CreatedUser", "HairColor", "IconId", "IsDeleted", "LeagueId", "ModifiedDate", "ModifiedUser", "Name", "NationId", "Skin", "Tattoo", "TeamId" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8201), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8202), "admin", 0, 1, false, 2, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8203), "admin", "Roberto Carlos", 2, 1, null, 4 },
                    { 3, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8204), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8205), "admin", 0, 1, false, 2, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8206), "admin", "Paulo Maldini", 2, 1, null, 4 },
                    { 4, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8207), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8208), "admin", 0, 1, false, 2, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8208), "admin", "Lucio", 2, 1, null, 4 },
                    { 5, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8209), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8210), "admin", 0, 1, false, 2, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8211), "admin", "Cafu", 2, 1, null, 4 },
                    { 6, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8212), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8213), "admin", 0, 1, false, 2, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8213), "admin", "Stevan Gerrard", 2, 1, null, 4 },
                    { 7, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8214), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8215), "admin", 0, 1, false, 2, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8216), "admin", "Philip Lahm", 2, 1, null, 4 },
                    { 8, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8217), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8218), "admin", 0, 1, false, 2, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8218), "admin", "Ronaldinho", 2, 1, null, 4 },
                    { 9, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8219), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8220), "admin", 0, 1, false, 2, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8221), "admin", "Cristiana Ronaldo", 2, 1, null, 4 },
                    { 10, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8222), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8223), "admin", 0, 1, false, 2, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8223), "admin", "Lionel Messi", 2, 1, null, 4 },
                    { 11, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8224), new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8225), "admin", 0, 1, false, 2, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(8226), "admin", "Ronaldo Nazario", 2, 1, null, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4962), new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4964) });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4966), false, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4967), "LB" },
                    { 3, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4968), false, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4968), "LCB" },
                    { 4, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4970), false, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4970), "RCB" },
                    { 5, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4971), false, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4971), "RB" },
                    { 6, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4972), false, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4973), "MOL" },
                    { 7, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4974), false, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4974), "MOR" },
                    { 8, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4975), false, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4975), "MOO" },
                    { 9, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4977), false, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(4977), "LF" },
                    { 10, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(5012), false, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(5013), "RF" },
                    { 11, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(5014), false, new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(5014), "ST" }
                });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(6103), new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(6105) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(7239), new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(7242) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(7245), new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(7247), new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(7248) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(7249), new DateTime(2024, 11, 4, 13, 44, 51, 750, DateTimeKind.Local).AddTicks(7250) });

            migrationBuilder.InsertData(
                table: "PlayerPositions",
                columns: new[] { "PlayerId", "PositionId", "CreatedDate", "IsDeleted", "ModifiedDate" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9829), false, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9829) },
                    { 3, 3, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9831), false, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9831) },
                    { 4, 4, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9832), false, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9833) },
                    { 5, 5, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9834), false, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9834) },
                    { 6, 6, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9835), false, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9835) },
                    { 7, 7, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9836), false, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9837) },
                    { 8, 8, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9838), false, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9838) },
                    { 9, 9, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9839), false, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9839) },
                    { 10, 10, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9840), false, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9841) },
                    { 11, 11, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9842), false, new DateTime(2024, 11, 4, 13, 44, 51, 749, DateTimeKind.Local).AddTicks(9842) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumns: new[] { "PlayerId", "PositionId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumns: new[] { "PlayerId", "PositionId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumns: new[] { "PlayerId", "PositionId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumns: new[] { "PlayerId", "PositionId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumns: new[] { "PlayerId", "PositionId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumns: new[] { "PlayerId", "PositionId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumns: new[] { "PlayerId", "PositionId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumns: new[] { "PlayerId", "PositionId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumns: new[] { "PlayerId", "PositionId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "PlayerPositions",
                keyColumns: new[] { "PlayerId", "PositionId" },
                keyValues: new object[] { 11, 11 });

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Positions",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.UpdateData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 809, DateTimeKind.Local).AddTicks(8282), new DateTime(2024, 10, 29, 23, 15, 37, 809, DateTimeKind.Local).AddTicks(8292) });

            migrationBuilder.UpdateData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 809, DateTimeKind.Local).AddTicks(8296), new DateTime(2024, 10, 29, 23, 15, 37, 809, DateTimeKind.Local).AddTicks(8296) });

            migrationBuilder.UpdateData(
                table: "Icons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 809, DateTimeKind.Local).AddTicks(9536), new DateTime(2024, 10, 29, 23, 15, 37, 809, DateTimeKind.Local).AddTicks(9539) });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(1389), new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(1391) });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(1393), new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(1393) });

            migrationBuilder.UpdateData(
                table: "Nations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(3943), new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(3945) });

            migrationBuilder.UpdateData(
                table: "Nations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(3947), new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(3947) });

            migrationBuilder.UpdateData(
                table: "PlayerPositions",
                keyColumns: new[] { "PlayerId", "PositionId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(7424), new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(7427) });

            migrationBuilder.UpdateData(
                table: "PlayerSkills",
                keyColumns: new[] { "PlayerId", "SkillId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(156), new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(159) });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedDate", "LeagueId", "ModifiedDate", "NationId", "TeamId" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(5873), new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(5879), 1, new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(5879), 1, 1 });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(2554), new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(2557) });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(3596), new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(3598) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(4724), new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(4726) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(4729), new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(4729) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(4731), new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(4731) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(4733), new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(4734) });
        }
    }
}
