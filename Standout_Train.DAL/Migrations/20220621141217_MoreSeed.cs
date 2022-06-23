using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Standout_Train.DAL.Migrations
{
    public partial class MoreSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DepartureTime",
                table: "Train",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ArrivalTime",
                table: "Train",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 1,
                column: "AquiredDate",
                value: new DateTime(2022, 6, 21, 17, 12, 17, 279, DateTimeKind.Local).AddTicks(4973));

            migrationBuilder.InsertData(
                table: "Train",
                columns: new[] { "Id", "ArrivalCity", "ArrivalTime", "DepartureCity", "DepartureTime", "Name", "Number", "RouteDistance", "SocietyId", "Type" },
                values: new object[,]
                {
                    { 1, "Bucuresti", new TimeSpan(0, 3, 58, 0, 0), "Brasov", new TimeSpan(0, 1, 17, 0, 0), "IRN1941", 1941, 165.0, 3, "IRN" },
                    { 2, "Bucuresti", new TimeSpan(0, 5, 5, 0, 0), "Brasov", new TimeSpan(0, 2, 22, 0, 0), "IRN1932", 1932, 165.0, 3, "IRN" },
                    { 3, "Bucuresti", new TimeSpan(0, 19, 34, 0, 0), "Brasov", new TimeSpan(0, 16, 56, 0, 0), "IR1734", 1734, 166.0, 1, "IR" },
                    { 4, "Bucuresti", new TimeSpan(0, 19, 58, 0, 0), "Brasov", new TimeSpan(0, 17, 25, 0, 0), "R-E11536", 1136, 166.0, 4, "R-E" },
                    { 5, "Bucuresti", new TimeSpan(0, 21, 13, 0, 0), "Brasov", new TimeSpan(0, 18, 38, 0, 0), "R-E11538", 11538, 166.0, 4, "R-E" },
                    { 6, "Constanta", new TimeSpan(0, 6, 29, 0, 0), "Brasov", new TimeSpan(0, 1, 8, 0, 0), "IRN1941", 1941, 383.0, 1, "IRN" },
                    { 7, "Constanta", new TimeSpan(0, 11, 32, 0, 0), "Brasov", new TimeSpan(0, 7, 12, 0, 0), "IRN1884", 1884, 390.0, 1, "IRN" },
                    { 8, "Bucuresti", new TimeSpan(0, 7, 10, 0, 0), "Brasov", new TimeSpan(0, 18, 38, 0, 0), "IRN1741", 1741, 649.0, 1, "IRN" },
                    { 9, "Sibiu", new TimeSpan(0, 15, 41, 0, 0), "Bucuresti", new TimeSpan(0, 9, 55, 0, 0), "IR1623", 1623, 315.0, 1, "IR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Train",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Train",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Train",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Train",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Train",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Train",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Train",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Train",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Train",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepartureTime",
                table: "Train",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArrivalTime",
                table: "Train",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 1,
                column: "AquiredDate",
                value: new DateTime(2022, 6, 21, 16, 28, 42, 755, DateTimeKind.Local).AddTicks(4708));
        }
    }
}
