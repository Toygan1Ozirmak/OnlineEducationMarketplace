using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OEMAP.Api.Migrations
{
    public partial class url : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Courses",  // Courses tablosu yerine kendi tablonuzun adını kullanmalısınız
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoURL",
                table: "Courses",  // Courses tablosu yerine kendi tablonuzun adını kullanmalısınız
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Courses");  // Courses tablosu yerine kendi tablonuzun adını kullanmalısınız

            migrationBuilder.DropColumn(
                name: "VideoURL",
                table: "Courses");  // Courses tablosu yerine kendi tablonuzun adını kullanmalısınız
        }
    }
}
