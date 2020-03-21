using Microsoft.EntityFrameworkCore.Migrations;

namespace DiseaseDataPlatform.DiseaseEntity.Migrations
{
    public partial class 修改湖北疫情信息表的字段 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryRate",
                table: "HubeiDiseaseDaily");

            migrationBuilder.AlterColumn<int>(
                name: "NotHebeiAddQty",
                table: "HubeiDiseaseDaily",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "CountryHealRate",
                table: "HubeiDiseaseDaily",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryHealRate",
                table: "HubeiDiseaseDaily");

            migrationBuilder.AlterColumn<int>(
                name: "NotHebeiAddQty",
                table: "HubeiDiseaseDaily",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CountryRate",
                table: "HubeiDiseaseDaily",
                type: "double",
                nullable: true);
        }
    }
}
