using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Standout_Train.DAL.Migrations
{
    public partial class NullableCostumer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LoyaltyPoints",
                table: "Customer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 1,
                column: "AquiredDate",
                value: new DateTime(2022, 6, 23, 22, 30, 28, 168, DateTimeKind.Local).AddTicks(5522));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LoyaltyPoints",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 1,
                column: "AquiredDate",
                value: new DateTime(2022, 6, 21, 17, 12, 17, 279, DateTimeKind.Local).AddTicks(4973));
        }
    }
}
