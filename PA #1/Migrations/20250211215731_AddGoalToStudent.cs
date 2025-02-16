using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PA__1.Migrations
{
    /// <inheritdoc />
    public partial class AddGoalToStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Goal",
                table: "Students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Goal" },
                values: new object[] { new DateTime(2005, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Become a scientist" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "Goal" },
                values: new object[] { new DateTime(2007, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Become a musician" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Goal",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(1971, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(1973, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
