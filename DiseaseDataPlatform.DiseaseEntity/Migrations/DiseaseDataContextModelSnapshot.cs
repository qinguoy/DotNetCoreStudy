﻿// <auto-generated />
using System;
using DiseaseDataPlatform.DiseaseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiseaseDataPlatform.DiseaseEntity.Migrations
{
    [DbContext(typeof(DiseaseDataContext))]
    partial class DiseaseDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DiseaseDataPlatform.DiseaseEntity.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("CanUse")
                        .HasColumnType("int");

                    b.Property<string>("CmsId")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(4000);

                    b.Property<Guid>("DiseaseRecordId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Media")
                        .HasColumnType("varchar(250) CHARACTER SET utf8mb4")
                        .HasMaxLength(250);

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Source")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<string>("Title")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<string>("Url")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("DiseaseRecordId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("DiseaseDataPlatform.DiseaseEntity.ChinaDiseaseDailyStatistics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("ConfirmQty")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Date")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("DeadQty")
                        .HasColumnType("int");

                    b.Property<double?>("DeadRate")
                        .HasColumnType("double");

                    b.Property<int?>("HealQty")
                        .HasColumnType("int");

                    b.Property<double>("HealRate")
                        .HasColumnType("double");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("SuspectQty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DiseaseDailyStatistics");
                });

            modelBuilder.Entity("DiseaseDataPlatform.DiseaseEntity.CityDiseaseRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("City")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<int?>("ConfirmQty")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DeadQty")
                        .HasColumnType("int");

                    b.Property<double?>("DeadRate")
                        .HasColumnType("double");

                    b.Property<int?>("HealQty")
                        .HasColumnType("int");

                    b.Property<double?>("HealRate")
                        .HasColumnType("double");

                    b.Property<bool>("IsUpdated")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ProvinceDiseaseRecordId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("ShowHeal")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("ShowRate")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("StatDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("SuspectQty")
                        .HasColumnType("int");

                    b.Property<int?>("TodayConfirmQty")
                        .HasColumnType("int");

                    b.Property<int?>("TodayDeadQty")
                        .HasColumnType("int");

                    b.Property<int?>("TodayHealQty")
                        .HasColumnType("int");

                    b.Property<int?>("TodaySuspectQty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceDiseaseRecordId");

                    b.ToTable("CityDiseaseRecord");
                });

            modelBuilder.Entity("DiseaseDataPlatform.DiseaseEntity.CountryDiseaseRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("ConfirmQty")
                        .HasColumnType("int");

                    b.Property<string>("CountryName")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DeadQty")
                        .HasColumnType("int");

                    b.Property<double?>("DeadRate")
                        .HasColumnType("double");

                    b.Property<int?>("HealQty")
                        .HasColumnType("int");

                    b.Property<double?>("HealRate")
                        .HasColumnType("double");

                    b.Property<bool>("IsUpdated")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("ShowHeal")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("ShowRate")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("StatDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("SuspectQty")
                        .HasColumnType("int");

                    b.Property<int?>("TodayDeadQty")
                        .HasColumnType("int");

                    b.Property<int?>("TodayHealQty")
                        .HasColumnType("int");

                    b.Property<int?>("TodaySuspectQty")
                        .HasColumnType("int");

                    b.Property<int?>("TodayconfirmQty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CountryDiseaseRecord");
                });

            modelBuilder.Entity("DiseaseDataPlatform.DiseaseEntity.DiseaseDailyAdd", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("ConfirmQty")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Date")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("DeadQty")
                        .HasColumnType("int");

                    b.Property<double?>("DeadRate")
                        .HasColumnType("double");

                    b.Property<int?>("HealQty")
                        .HasColumnType("int");

                    b.Property<double?>("HealRate")
                        .HasColumnType("double");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("SuspectQty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DiseaseDailyAdd");
                });

            modelBuilder.Entity("DiseaseDataPlatform.DiseaseEntity.DiseaseRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("DiseaseRecord");
                });

            modelBuilder.Entity("DiseaseDataPlatform.DiseaseEntity.HubeiDiseaseDaily", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("CountryAddQty")
                        .HasColumnType("int");

                    b.Property<double?>("CountryDeadRate")
                        .HasColumnType("double");

                    b.Property<double?>("CountryHealRate")
                        .HasColumnType("double");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Date")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("HubeiAddQty")
                        .HasColumnType("int");

                    b.Property<double?>("HubeiDeadRate")
                        .HasColumnType("double");

                    b.Property<double?>("HubeiHealRate")
                        .HasColumnType("double");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("NotHebeiAddQty")
                        .HasColumnType("int");

                    b.Property<double?>("NotHebeiDeadRate")
                        .HasColumnType("double");

                    b.Property<double?>("NotHubeiHealRate")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("HubeiDiseaseDaily");
                });

            modelBuilder.Entity("DiseaseDataPlatform.DiseaseEntity.ProvinceDiseaseRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("ConfirmQty")
                        .HasColumnType("int");

                    b.Property<Guid>("CountryDiseaseRecordId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DeadQty")
                        .HasColumnType("int");

                    b.Property<double?>("DeadRate")
                        .HasColumnType("double");

                    b.Property<int?>("HealQty")
                        .HasColumnType("int");

                    b.Property<double?>("HealRate")
                        .HasColumnType("double");

                    b.Property<bool>("IsUpdated")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Province")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<bool>("ShowHeal")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("ShowRate")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("StatDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("SuspectQty")
                        .HasColumnType("int");

                    b.Property<int?>("TodayConfirmQty")
                        .HasColumnType("int");

                    b.Property<int?>("TodayDeadQty")
                        .HasColumnType("int");

                    b.Property<int?>("TodayHealQty")
                        .HasColumnType("int");

                    b.Property<int?>("TodaySuspectQty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryDiseaseRecordId");

                    b.ToTable("ProvinceDiseaseRecord");
                });

            modelBuilder.Entity("DiseaseDataPlatform.DiseaseEntity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(120) CHARACTER SET utf8mb4")
                        .HasMaxLength(120);

                    b.Property<int>("Enabled")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DiseaseDataPlatform.DiseaseEntity.Article", b =>
                {
                    b.HasOne("DiseaseDataPlatform.DiseaseEntity.DiseaseRecord", "DiseaseRecord")
                        .WithMany()
                        .HasForeignKey("DiseaseRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiseaseDataPlatform.DiseaseEntity.CityDiseaseRecord", b =>
                {
                    b.HasOne("DiseaseDataPlatform.DiseaseEntity.ProvinceDiseaseRecord", "ProvinceDiseaseRecord")
                        .WithMany("CityDiseaseRecordList")
                        .HasForeignKey("ProvinceDiseaseRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiseaseDataPlatform.DiseaseEntity.ProvinceDiseaseRecord", b =>
                {
                    b.HasOne("DiseaseDataPlatform.DiseaseEntity.CountryDiseaseRecord", "CountryDiseaseRecord")
                        .WithMany("ProvinceDiseaseRecordList")
                        .HasForeignKey("CountryDiseaseRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}