using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class AnotherTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RandomChange",
                schema: "ex",
                table: "ToDo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RandomChange2",
                schema: "ex",
                table: "ToDo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RandomChange",
                schema: "ex",
                table: "ToDo");

            migrationBuilder.DropColumn(
                name: "RandomChange2",
                schema: "ex",
                table: "ToDo");
        }
    }
}
