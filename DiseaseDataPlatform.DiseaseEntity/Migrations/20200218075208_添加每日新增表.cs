using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiseaseDataPlatform.DiseaseEntity.Migrations
{
    public partial class 添加每日新增表 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiseaseDailyAdd",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ConfirmQty = table.Column<int>(nullable: true),
                    SuspectQty = table.Column<int>(nullable: true),
                    DeadQty = table.Column<int>(nullable: true),
                    HealQty = table.Column<int>(nullable: true),
                    DeadRate = table.Column<double>(nullable: true),
                    HealRate = table.Column<double>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseDailyAdd", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiseaseDailyAdd");
        }
    }
}
