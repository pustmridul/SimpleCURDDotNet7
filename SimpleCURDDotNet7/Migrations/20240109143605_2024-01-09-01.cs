using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCURDDotNet7.Migrations
{
    /// <inheritdoc />
    public partial class _2024010901 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "CreateByName", "CreateDate", "Password", "RefreshToken", "RefreshTokenExpiryTime", "UpdateByName", "UpdateDate", "UserName" },
                values: new object[] { 1, "System", new DateTime(2024, 1, 9, 14, 36, 5, 689, DateTimeKind.Utc).AddTicks(6934), "1234", null, null, null, null, "test" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
