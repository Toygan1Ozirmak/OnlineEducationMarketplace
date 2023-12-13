using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OEMAP.Api.Migrations
{
    public partial class backtoimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ImageData",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "DefaultImagePath",
                table: "Courses",
                newName: "Image");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "34551344-1bf6-4912-b4b7-c64ba6d89e83", "76b9801d-e333-4ca6-98c3-7293c47986ac", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf135080-d000-497f-9088-25fa2dbdc3ae", "bdd8c637-6bd3-41cd-9352-cb634d753a78", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e707cb23-5005-464b-a39d-0d57dfb56c61", "b4821cd3-66b0-4e2c-afb1-167a4332304e", "instructor", "INSTRUCTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34551344-1bf6-4912-b4b7-c64ba6d89e83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf135080-d000-497f-9088-25fa2dbdc3ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e707cb23-5005-464b-a39d-0d57dfb56c61");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Courses",
                newName: "DefaultImagePath");

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
    }
}
