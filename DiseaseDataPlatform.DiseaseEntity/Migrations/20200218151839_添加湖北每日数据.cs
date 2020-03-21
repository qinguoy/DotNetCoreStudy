using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiseaseDataPlatform.DiseaseEntity.Migrations
{
    public partial class 添加湖北每日数据 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HubeiDiseaseDaily",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    HubeiAddQty = table.Column<int>(nullable: true),
                    CountryAddQty = table.Column<int>(nullable: true),
                    NotHebeiAddQty = table.Column<int>(nullable: false),
                    HubeiDeadRate = table.Column<double>(nullable: true),
                    NotHebeiDeadRate = table.Column<double>(nullable: true),
                    CountryDeadRate = table.Column<double>(nullable: true),
                    HubeiHealRate = table.Column<double>(nullable: true),
                    NotHubeiHealRate = table.Column<double>(nullable: true),
                    CountryRate = table.Column<double>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubeiDiseaseDaily", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HubeiDiseaseDaily");
        }
    }
}
