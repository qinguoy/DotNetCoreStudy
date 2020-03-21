using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qingy.DotNetCoreStudy.HangfireJobEntity.Migrations
{
    public partial class 添加作业触发器 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cron",
                table: "HangfireTask");

            migrationBuilder.AddColumn<string>(
                name: "ExecuteClassName",
                table: "HangfireTask",
                maxLength: 300,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HangfireTaskTrigger",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    HangfireTaskId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Cron = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangfireTaskTrigger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HangfireTaskTrigger_HangfireTask_HangfireTaskId",
                        column: x => x.HangfireTaskId,
                        principalTable: "HangfireTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangfireTaskTrigger_HangfireTaskId",
                table: "HangfireTaskTrigger",
                column: "HangfireTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangfireTaskTrigger");

            migrationBuilder.DropColumn(
                name: "ExecuteClassName",
                table: "HangfireTask");

            migrationBuilder.AddColumn<string>(
                name: "Cron",
                table: "HangfireTask",
                type: "varchar(100) CHARACTER SET utf8mb4",
                maxLength: 100,
                nullable: true);
        }
    }
}
