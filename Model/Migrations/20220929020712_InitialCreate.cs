using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ex");

            migrationBuilder.CreateTable(
                name: "ToDoStatus",
                schema: "ex",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoStatus", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "ToDo",
                schema: "ex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StatusKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_StatusKey_ToDoStatus_Key",
                        column: x => x.StatusKey,
                        principalSchema: "ex",
                        principalTable: "ToDoStatus",
                        principalColumn: "Key");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_StatusKey",
                schema: "ex",
                table: "ToDo",
                column: "StatusKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDo",
                schema: "ex");

            migrationBuilder.DropTable(
                name: "ToDoStatus",
                schema: "ex");
        }
    }
}
