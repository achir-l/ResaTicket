using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResaTicket.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeanceCinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaSeance");

           

            migrationBuilder.AddColumn<float>(
                name: "prix",
                table: "Tarif",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CinemaID",
                table: "Seance",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seance_CinemaID",
                table: "Seance",
                column: "CinemaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Seance_Cinema_CinemaID",
                table: "Seance",
                column: "CinemaID",
                principalTable: "Cinema",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seance_Cinema_CinemaID",
                table: "Seance");

            migrationBuilder.DropIndex(
                name: "IX_Seance_CinemaID",
                table: "Seance");

            migrationBuilder.DropColumn(
                name: "prix",
                table: "Tarif");

            migrationBuilder.DropColumn(
                name: "CinemaID",
                table: "Seance");

            migrationBuilder.CreateTable(
                name: "CinemaSeance",
                columns: table => new
                {
                    CinemasID = table.Column<int>(type: "int", nullable: false),
                    SeancesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaSeance", x => new { x.CinemasID, x.SeancesID });
                    table.ForeignKey(
                        name: "FK_CinemaSeance_Cinema_CinemasID",
                        column: x => x.CinemasID,
                        principalTable: "Cinema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemaSeance_Seance_SeancesID",
                        column: x => x.SeancesID,
                        principalTable: "Seance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_CinemaSeance_SeancesID",
                table: "CinemaSeance",
                column: "SeancesID");

          
        }
    }
}
