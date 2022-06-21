using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Standout_Train.DAL.Migrations
{
    public partial class AddedReportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 1,
                column: "AquiredDate",
                value: new DateTime(2022, 6, 21, 16, 28, 42, 755, DateTimeKind.Local).AddTicks(4708));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 1,
                column: "AquiredDate",
                value: new DateTime(2022, 5, 24, 17, 1, 37, 680, DateTimeKind.Local).AddTicks(2360));
        }
    }
}
