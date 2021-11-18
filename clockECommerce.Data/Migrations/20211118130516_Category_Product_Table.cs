using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clockECommerce.Data.Migrations
{
    public partial class Category_Product_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    originPrice = table.Column<decimal>(type: "decimal(18,2)", maxLength: 100000000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 100000000, nullable: false),
                    Stock = table.Column<int>(type: "int", maxLength: 100, nullable: false, defaultValue: 0),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ProductImage = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeDescription",
                column: "Value",
                value: "This is description of Clock ECommerce");

            migrationBuilder.UpdateData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeKeyword",
                column: "Value",
                value: "This is keyword of Clock ECommerce");

            migrationBuilder.UpdateData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeTitle",
                column: "Value",
                value: "This is home page of Clock ECommerce");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "6c79820c-a6f1-46c0-810b-e75d655e402f");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1bc0eb50-0dfd-4894-a151-974028e542c3", "AQAAAAEAACcQAAAAEPqU78OnPQvSzHgZ2iHdFHk4rwaYIJTAqBYsCF33wlZvftez96q1ZDxeuaTNCoOVvQ==" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Daniel Wellington" },
                    { 2, "Casio" },
                    { 3, "Citizen" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "Description", "Details", "Name", "Price", "ProductImage", "Stock", "Thumbnail", "originPrice" },
                values: new object[] { 1, 1, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "DANIEL WELLINGTON DW00100414", 6600000m, null, 5, null, 6000000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "Description", "Details", "Name", "Price", "ProductImage", "Stock", "Thumbnail", "originPrice" },
                values: new object[] { 2, 2, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "CASIO EFB-302JD-1ADR", 10882000m, null, 5, null, 10000000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "Description", "Details", "Name", "Price", "ProductImage", "Stock", "Thumbnail", "originPrice" },
                values: new object[] { 3, 3, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "CITIZEN NB1021-57E", 14700000m, null, 5, null, 14000000m });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeDescription",
                column: "Value",
                value: "This is description of clb IT HUFLIT");

            migrationBuilder.UpdateData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeKeyword",
                column: "Value",
                value: "This is keyword of clb IT HUFLIT");

            migrationBuilder.UpdateData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeTitle",
                column: "Value",
                value: "This is home page of clb IT HUFLIT");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "bd5fb9df-d902-4181-9b35-7122c75f9bee");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "105a2fd2-0967-4906-a5f9-7edfbcb19d3c", "AQAAAAEAACcQAAAAELRi9A/5khNaL6R60bHlkj/fOymkDcBkUbeXEGTscq/rtQJgDlxQQnXFD++R036WtA==" });
        }
    }
}
