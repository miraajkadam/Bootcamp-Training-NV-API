﻿// <auto-generated />
using System;
using Bootcamp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bootcamp.Data.Migrations
{
    [DbContext(typeof(EngagementDbContext))]
    [Migration("20240911101946_Init_DB_4")]
    partial class Init_DB_4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bootcamp.Data.Models.AuditType", b =>
                {
                    b.Property<int>("AuditTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuditTypeId");

                    b.ToTable("AuditType");

                    b.HasData(
                        new
                        {
                            AuditTypeId = 0,
                            Name = "InternalAudit"
                        },
                        new
                        {
                            AuditTypeId = 1,
                            Name = "ExternalAudit"
                        },
                        new
                        {
                            AuditTypeId = 2,
                            Name = "ComplianceAudit"
                        },
                        new
                        {
                            AuditTypeId = 3,
                            Name = "FinancialAudit"
                        });
                });

            modelBuilder.Entity("Bootcamp.Data.Models.AuthUser", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuthUser");
                });

            modelBuilder.Entity("Bootcamp.Data.Models.Engagement", b =>
                {
                    b.Property<int>("EngagementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EngagementId"));

                    b.Property<DateTimeOffset>("AuditEndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("AuditStartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("AuditTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Auditors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int?>("EngagementStatusId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("EngagementId");

                    b.HasIndex("AuditTypeId");

                    b.HasIndex("EngagementStatusId");

                    b.ToTable("Engagements");
                });

            modelBuilder.Entity("Bootcamp.Data.Models.EngagementBackup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("AuditEndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("AuditStartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("AuditTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Auditors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BackupId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BackupTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("EngagementId")
                        .HasColumnType("int");

                    b.Property<int>("EngagementStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EngagementBackups");
                });

            modelBuilder.Entity("Bootcamp.Data.Models.EngagementSetting", b =>
                {
                    b.Property<int>("SettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SettingId"));

                    b.Property<string>("DataType")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InsertedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KeyName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("ValueBigInt")
                        .HasColumnType("bigint");

                    b.Property<string>("ValueChar")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime?>("ValueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ValueDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ValueDateTime2")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset?>("ValueDateTimeOffSet")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal?>("ValueDecimal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float?>("ValueFloat")
                        .HasColumnType("real");

                    b.Property<int?>("ValueInt")
                        .HasColumnType("int");

                    b.Property<decimal?>("ValueMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ValueNumeric")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float?>("ValueReal")
                        .HasColumnType("real");

                    b.Property<DateTime?>("ValueSmallDateTime")
                        .HasColumnType("datetime2");

                    b.Property<short?>("ValueSmallInt")
                        .HasColumnType("smallint");

                    b.Property<decimal?>("ValueSmallMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<TimeSpan?>("ValueTime")
                        .HasColumnType("time");

                    b.Property<byte?>("ValueTinyInt")
                        .HasColumnType("tinyint");

                    b.Property<string>("ValueVarChar")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("SettingId");

                    b.ToTable("EngagementSettings");
                });

            modelBuilder.Entity("Bootcamp.Data.Models.EngagementStatus", b =>
                {
                    b.Property<int>("EngagementStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EngagementStatusId");

                    b.ToTable("EngagementStatus");

                    b.HasData(
                        new
                        {
                            EngagementStatusId = 0,
                            Name = "NotStarted"
                        },
                        new
                        {
                            EngagementStatusId = 1,
                            Name = "Assigned"
                        },
                        new
                        {
                            EngagementStatusId = 2,
                            Name = "InProgress"
                        },
                        new
                        {
                            EngagementStatusId = 3,
                            Name = "Completed"
                        });
                });

            modelBuilder.Entity("Bootcamp.Data.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "role");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "username");

                    b.HasKey("Id");

                    b.ToTable("UserList");
                });

            modelBuilder.Entity("Bootcamp.Data.Models.Engagement", b =>
                {
                    b.HasOne("Bootcamp.Data.Models.AuditType", null)
                        .WithMany("Engagements")
                        .HasForeignKey("AuditTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bootcamp.Data.Models.EngagementStatus", null)
                        .WithMany("Engagements")
                        .HasForeignKey("EngagementStatusId");
                });

            modelBuilder.Entity("Bootcamp.Data.Models.AuditType", b =>
                {
                    b.Navigation("Engagements");
                });

            modelBuilder.Entity("Bootcamp.Data.Models.EngagementStatus", b =>
                {
                    b.Navigation("Engagements");
                });
#pragma warning restore 612, 618
        }
    }
}
