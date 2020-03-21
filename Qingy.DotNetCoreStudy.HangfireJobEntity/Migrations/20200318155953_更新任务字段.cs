using Microsoft.EntityFrameworkCore.Migrations;

namespace Qingy.DotNetCoreStudy.HangfireJobEntity.Migrations
{
    public partial class 更新任务字段 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskClassName",
                table: "HangfireTask");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaskClassName",
                table: "HangfireTask",
                type: "varchar(100) CHARACTER SET utf8mb4",
                maxLength: 100,
                nullable: true);
        }
    }
}
