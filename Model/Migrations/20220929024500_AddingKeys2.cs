using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class AddingKeys2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey("PK_ID", "ToDo", "Id", "ex");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
