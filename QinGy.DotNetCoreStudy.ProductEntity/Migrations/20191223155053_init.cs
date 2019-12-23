using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QinGy.MarketPlatform.ProductCenterEntity.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sku = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Tags = table.Column<string>(maxLength: 250, nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Msrp = table.Column<string>(maxLength: 100, nullable: true),
                    MainImage = table.Column<string>(maxLength: 250, nullable: true),
                    CleanImage = table.Column<string>(maxLength: 250, nullable: true),
                    ExtraImage = table.Column<string>(maxLength: 500, nullable: true),
                    Brand = table.Column<string>(maxLength: 80, nullable: true),
                    Upc = table.Column<string>(maxLength: 80, nullable: true),
                    Length = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ProductType = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
