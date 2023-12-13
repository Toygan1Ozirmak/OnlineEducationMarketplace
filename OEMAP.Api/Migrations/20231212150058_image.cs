using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OEMAP.Api.Migrations
{
    public partial class image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1708fc0d-67f4-4ec0-ba4b-91abee3f7956");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8499013e-e04d-4467-bee2-5e81235c9bab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99aad4ed-1e32-41fb-9f2f-f47eb35efbed");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CourseStatus",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "CourseLength",
                table: "Courses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultImagePath",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Courses",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3491e8d6-9259-40ce-980d-90c365e2a9ef", "a13fbdba-aa4c-4d42-9919-c990d1486927", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "59b35b22-61a6-4bbd-b636-734aa13e9ae1", "4930cc9e-6989-4187-aa0b-90d6c0e55de8", "instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8000875b-6423-4a22-abf8-f4e2c07e8e4d", "71de3ce8-21cb-4224-b6a5-7af0d1b5a6dc", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3491e8d6-9259-40ce-980d-90c365e2a9ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59b35b22-61a6-4bbd-b636-734aa13e9ae1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8000875b-6423-4a22-abf8-f4e2c07e8e4d");

            migrationBuilder.DropColumn(
                name: "DefaultImagePath",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Courses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "CourseStatus",
                table: "Courses",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "CourseLength",
                table: "Courses",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1708fc0d-67f4-4ec0-ba4b-91abee3f7956", "98c06176-f772-4a55-a0b0-51436205b40c", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8499013e-e04d-4467-bee2-5e81235c9bab", "85da4d2e-d558-43e6-b899-ab3b2d030b63", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99aad4ed-1e32-41fb-9f2f-f47eb35efbed", "eea6a0dd-fecb-4d4b-b4bc-9ffc7d507a91", "instructor", "INSTRUCTOR" });
        }
    }
}
