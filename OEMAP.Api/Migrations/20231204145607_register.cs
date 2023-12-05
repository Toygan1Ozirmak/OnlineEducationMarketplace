using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OEMAP.Api.Migrations
{
    public partial class register : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c5b9184-07e7-49c6-a324-e86b4d524c36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9946857a-ba3a-47c8-ae45-6c6000318750");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f98360a7-c0ed-45a8-990c-4b8d18298201");

            migrationBuilder.AddColumn<string>(
                name: "UserBio",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "UserBio",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c5b9184-07e7-49c6-a324-e86b4d524c36", "6b5d8c21-88e9-46e1-a8f5-bac00952bf41", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9946857a-ba3a-47c8-ae45-6c6000318750", "1260aef3-4e85-449b-a35f-d4482106bc67", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f98360a7-c0ed-45a8-990c-4b8d18298201", "e1e107a2-84d4-41f4-8747-c604fdec3543", "instructor", "INSTRUCTOR" });
        }
    }
}
