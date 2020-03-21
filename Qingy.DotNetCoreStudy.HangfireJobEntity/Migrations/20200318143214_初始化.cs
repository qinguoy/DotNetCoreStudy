using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qingy.DotNetCoreStudy.HangfireJobEntity.Migrations
{
    public partial class 初始化 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangfireTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    GroupId = table.Column<Guid>(nullable: false),
                    Cron = table.Column<string>(maxLength: 100, nullable: true),
                    Arguments = table.Column<string>(maxLength: 1000, nullable: true),
                    TaskClassName = table.Column<string>(maxLength: 100, nullable: true),
                    Queue = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangfireTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HangfireTaskGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GroupName = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangfireTaskGroup", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangfireTask");

            migrationBuilder.DropTable(
                name: "HangfireTaskGroup");
        }
    }
}
