using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clockECommerce.Data.Migrations
{
    public partial class ChangeStatusTableReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "0151a386-7107-4e8a-b7bf-84968597dff6");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "13a10ddd-7f7a-4a07-b6e7-2cb077d7a700", "AQAAAAEAACcQAAAAEGEkBQfvgtqpDhyx1VTNGGEikXDLAOdK3+ntVc/+S/MIODLfd79hp0eoL4IkWai3CQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "d6e48d97-db55-4fa1-bc61-642b40e97c67");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "73265850-62dc-46c1-8dad-391e5760df4a", "AQAAAAEAACcQAAAAEM0E4lajC9s62J6Ny1b9G+cmyEertBfIJfi0YbZhy5TDhPCKdp1P5bATdbELminaOg==" });
        }
    }
}
