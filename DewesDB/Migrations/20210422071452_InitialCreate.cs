using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DewesDB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataSink",
                columns: table => new
                {
                    DataSinkId = table.Column<Guid>(nullable: false),
                    NameLibrary = table.Column<string>(nullable: true),
                    Uri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSink", x => x.DataSinkId);
                });

            migrationBuilder.CreateTable(
                name: "DataSource",
                columns: table => new
                {
                    DataSourceId = table.Column<Guid>(nullable: false),
                    NameLibrary = table.Column<string>(nullable: true),
                    Uri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSource", x => x.DataSourceId);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<Guid>(nullable: false),
                    EDataSourceType = table.Column<int>(nullable: false),
                    EDataSourceFormat = table.Column<int>(nullable: false),
                    DataSourceId = table.Column<Guid>(nullable: false),
                    DataSinkId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_DataSink_DataSinkId",
                        column: x => x.DataSinkId,
                        principalTable: "DataSink",
                        principalColumn: "DataSinkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_DataSource_DataSourceId",
                        column: x => x.DataSourceId,
                        principalTable: "DataSource",
                        principalColumn: "DataSourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DataSinkId",
                table: "Schedules",
                column: "DataSinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DataSourceId",
                table: "Schedules",
                column: "DataSourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "DataSink");

            migrationBuilder.DropTable(
                name: "DataSource");
        }
    }
}
