using Microsoft.EntityFrameworkCore.Migrations;

namespace BenchmarkEFCoreDapper.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SportType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Athletes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Sportid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Athletes_Sports_Sportid",
                        column: x => x.Sportid,
                        principalTable: "Sports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_Sportid",
                table: "Athletes",
                column: "Sportid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Athletes");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
