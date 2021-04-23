﻿// <auto-generated />
using System;
using DEWESDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DewesDB.Migrations
{
    [DbContext(typeof(DbScheduleContext))]
    partial class DbScheduleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DEWESDb.Table.Schedule", b =>
                {
                    b.Property<Guid>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DataSinkName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataSourceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTimeCreate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EDataSourceFormat")
                        .HasColumnType("int");

                    b.Property<int>("EDataSourceType")
                        .HasColumnType("int");

                    b.Property<string>("Interval")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScheduleId");

                    b.ToTable("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
