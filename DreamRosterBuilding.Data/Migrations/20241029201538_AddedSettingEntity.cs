using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamRosterBuilding.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSettingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceMood = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

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
                columns: new[] { "BirthDate", "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(5873), new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(5879), new DateTime(2024, 10, 29, 23, 15, 37, 810, DateTimeKind.Local).AddTicks(5879) });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(2554), new DateTime(2024, 10, 29, 23, 15, 37, 811, DateTimeKind.Local).AddTicks(2557) });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "MaintenanceMood", "ModifiedDate", "Name" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, "Maintenance" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.UpdateData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(2241), new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(2248) });

            migrationBuilder.UpdateData(
                table: "Flags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(2251), new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(2251) });

            migrationBuilder.UpdateData(
                table: "Icons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(3584), new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(3587) });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(5431), new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(5434) });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(5436), new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(5436) });

            migrationBuilder.UpdateData(
                table: "Nations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(7942), new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(7945) });

            migrationBuilder.UpdateData(
                table: "Nations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(7947), new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(7948) });

            migrationBuilder.UpdateData(
                table: "PlayerPositions",
                keyColumns: new[] { "PlayerId", "PositionId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(1417), new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "PlayerSkills",
                keyColumns: new[] { "PlayerId", "SkillId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(4370), new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(4373) });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(9916), new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(9922), new DateTime(2024, 10, 29, 22, 6, 22, 41, DateTimeKind.Local).AddTicks(9922) });

            migrationBuilder.UpdateData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(6716), new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(6719) });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(7770), new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(7772) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8939), new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8942) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8946), new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8947) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8948), new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8949) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8951), new DateTime(2024, 10, 29, 22, 6, 22, 42, DateTimeKind.Local).AddTicks(8951) });
        }
    }
}
