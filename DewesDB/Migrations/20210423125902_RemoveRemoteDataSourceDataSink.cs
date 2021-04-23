using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DewesDB.Migrations
{
    public partial class RemoveRemoteDataSourceDataSink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_DataSink_DataSinkId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_DataSource_DataSourceId",
                table: "Schedules");

            migrationBuilder.DropTable(
                name: "DataSink");

            migrationBuilder.DropTable(
                name: "DataSource");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_DataSinkId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_DataSourceId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "DataSinkId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "DataSourceId",
                table: "Schedules");

            migrationBuilder.AddColumn<string>(
                name: "DataSinkName",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataSourceName",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeCreate",
                table: "Schedules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Interval",
                table: "Schedules",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataSinkName",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "DataSourceName",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "DateTimeCreate",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Interval",
                table: "Schedules");

            migrationBuilder.AddColumn<Guid>(
                name: "DataSinkId",
                table: "Schedules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DataSourceId",
                table: "Schedules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DataSink",
                columns: table => new
                {
                    DataSinkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameLibrary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSink", x => x.DataSinkId);
                });

            migrationBuilder.CreateTable(
                name: "DataSource",
                columns: table => new
                {
                    DataSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameLibrary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSource", x => x.DataSourceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DataSinkId",
                table: "Schedules",
                column: "DataSinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DataSourceId",
                table: "Schedules",
                column: "DataSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_DataSink_DataSinkId",
                table: "Schedules",
                column: "DataSinkId",
                principalTable: "DataSink",
                principalColumn: "DataSinkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_DataSource_DataSourceId",
                table: "Schedules",
                column: "DataSourceId",
                principalTable: "DataSource",
                principalColumn: "DataSourceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
