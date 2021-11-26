using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clockECommerce.Data.Migrations
{
    public partial class update_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "5a0af7af-f371-4787-ba94-202c1fc3c103");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e9c1e096-d13b-4e89-9ae1-f681686e5ddf", "AQAAAAEAACcQAAAAENl0GKx/b1TNK+vBV6fMwtMQtAqaX0qrhocO+LyOnzBVkW6aBgKWMJLmuKC5bhoSwg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppRoles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b66e1498-c66f-4c0f-bf84-3c1673b5c29e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "990c5909-f4ad-4c55-a6d7-94d704d4201b", "AQAAAAEAACcQAAAAEIxAqNbmKFBS66SVfnhPcsFoN4Nf4KBIWbrcFGggokCTzWODYN2B/1KULBoAax6vRQ==" });
        }
    }
}
