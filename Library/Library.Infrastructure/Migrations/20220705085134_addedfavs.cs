using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    public partial class addedfavs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientComicBook",
                columns: table => new
                {
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    ComicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientComicBook", x => new { x.ClientsId, x.ComicsId });
                    table.ForeignKey(
                        name: "FK_ClientComicBook_Clients_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientComicBook_ComicBooks_ComicsId",
                        column: x => x.ComicsId,
                        principalTable: "ComicBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientComicBook_ComicsId",
                table: "ClientComicBook",
                column: "ComicsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientComicBook");
        }
    }
}
