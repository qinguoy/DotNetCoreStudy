using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiseaseDataPlatform.DiseaseEntity.Migrations
{
    public partial class 添加用户建模 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 80, nullable: true),
                    Email = table.Column<string>(maxLength: 120, nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Enabled = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
