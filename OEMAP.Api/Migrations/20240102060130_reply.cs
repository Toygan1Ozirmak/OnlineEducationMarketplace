using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OEMAP.Api.Migrations
{
    public partial class reply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    ReplyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.ReplyId);
                    table.ForeignKey(
                        name: "FK_Replies_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Replies_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af6f95fa-9ded-49bf-8e94-2f9b77c74876", "044e6b9e-f57d-4639-bab8-e2ffe4cc01a0", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf9769f4-3c94-4f3e-a944-f35deaf4a462", "c4ae65ef-e692-4ed6-b13c-c3d618b1c966", "instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed5c1c6b-3fb6-4e2d-9a85-8f8f396274d1", "d9f9ea19-5ee2-499e-bbb2-2a18a48032af", "user", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_Replies_Id",
                table: "Replies",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_ReviewId",
                table: "Replies",
                column: "ReviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af6f95fa-9ded-49bf-8e94-2f9b77c74876");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf9769f4-3c94-4f3e-a944-f35deaf4a462");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed5c1c6b-3fb6-4e2d-9a85-8f8f396274d1");

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
    }
}
