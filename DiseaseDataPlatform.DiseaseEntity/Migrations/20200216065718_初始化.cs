using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiseaseDataPlatform.DiseaseEntity.Migrations
{
    public partial class 初始化 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryDiseaseRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CountryName = table.Column<string>(maxLength: 100, nullable: true),
                    TodayconfirmQty = table.Column<int>(nullable: true),
                    TodaySuspectQty = table.Column<int>(nullable: true),
                    TodayDeadQty = table.Column<int>(nullable: true),
                    TodayHealQty = table.Column<int>(nullable: true),
                    IsUpdated = table.Column<bool>(nullable: false),
                    ConfirmQty = table.Column<int>(nullable: true),
                    SuspectQty = table.Column<int>(nullable: true),
                    DeadQty = table.Column<int>(nullable: true),
                    HealQty = table.Column<int>(nullable: true),
                    ShowRate = table.Column<bool>(nullable: false),
                    ShowHeal = table.Column<bool>(nullable: false),
                    DeadRate = table.Column<double>(nullable: true),
                    HealRate = table.Column<double>(nullable: true),
                    StatDate = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryDiseaseRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseDailyStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ConfirmQty = table.Column<int>(nullable: true),
                    SuspectQty = table.Column<int>(nullable: true),
                    DeadQty = table.Column<int>(nullable: true),
                    HealQty = table.Column<int>(nullable: true),
                    DeadRate = table.Column<double>(nullable: true),
                    HealRate = table.Column<double>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseDailyStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProvinceDiseaseRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CountryDiseaseRecordId = table.Column<Guid>(nullable: false),
                    Province = table.Column<string>(maxLength: 100, nullable: true),
                    TodayConfirmQty = table.Column<int>(nullable: true),
                    TodaySuspectQty = table.Column<int>(nullable: true),
                    TodayDeadQty = table.Column<int>(nullable: true),
                    TodayHealQty = table.Column<int>(nullable: true),
                    IsUpdated = table.Column<bool>(nullable: false),
                    ConfirmQty = table.Column<int>(nullable: true),
                    SuspectQty = table.Column<int>(nullable: true),
                    DeadQty = table.Column<int>(nullable: true),
                    HealQty = table.Column<int>(nullable: true),
                    ShowRate = table.Column<bool>(nullable: false),
                    ShowHeal = table.Column<bool>(nullable: false),
                    DeadRate = table.Column<double>(nullable: true),
                    HealRate = table.Column<double>(nullable: true),
                    StatDate = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvinceDiseaseRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvinceDiseaseRecord_CountryDiseaseRecord_CountryDiseaseRec~",
                        column: x => x.CountryDiseaseRecordId,
                        principalTable: "CountryDiseaseRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DiseaseRecordId = table.Column<Guid>(nullable: false),
                    CmsId = table.Column<string>(maxLength: 100, nullable: true),
                    source = table.Column<string>(maxLength: 200, nullable: true),
                    Media = table.Column<string>(maxLength: 250, nullable: true),
                    PublishTime = table.Column<DateTime>(nullable: false),
                    CanUse = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Url = table.Column<string>(maxLength: 500, nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_DiseaseRecord_DiseaseRecordId",
                        column: x => x.DiseaseRecordId,
                        principalTable: "DiseaseRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityDiseaseRecord",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProvinceDiseaseRecordId = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    TodayConfirmQty = table.Column<int>(nullable: true),
                    TodaySuspectQty = table.Column<int>(nullable: true),
                    TodayDeadQty = table.Column<int>(nullable: true),
                    TodayHealQty = table.Column<int>(nullable: true),
                    IsUpdated = table.Column<bool>(nullable: false),
                    ConfirmQty = table.Column<int>(nullable: true),
                    SuspectQty = table.Column<int>(nullable: true),
                    DeadQty = table.Column<int>(nullable: true),
                    HealQty = table.Column<int>(nullable: true),
                    ShowRate = table.Column<bool>(nullable: false),
                    ShowHeal = table.Column<bool>(nullable: false),
                    DeadRate = table.Column<double>(nullable: true),
                    HealRate = table.Column<double>(nullable: true),
                    StatDate = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityDiseaseRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityDiseaseRecord_ProvinceDiseaseRecord_ProvinceDiseaseRecor~",
                        column: x => x.ProvinceDiseaseRecordId,
                        principalTable: "ProvinceDiseaseRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_DiseaseRecordId",
                table: "Article",
                column: "DiseaseRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_CityDiseaseRecord_ProvinceDiseaseRecordId",
                table: "CityDiseaseRecord",
                column: "ProvinceDiseaseRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvinceDiseaseRecord_CountryDiseaseRecordId",
                table: "ProvinceDiseaseRecord",
                column: "CountryDiseaseRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "CityDiseaseRecord");

            migrationBuilder.DropTable(
                name: "DiseaseDailyStatistics");

            migrationBuilder.DropTable(
                name: "DiseaseRecord");

            migrationBuilder.DropTable(
                name: "ProvinceDiseaseRecord");

            migrationBuilder.DropTable(
                name: "CountryDiseaseRecord");
        }
    }
}
