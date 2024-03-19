using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResaTicket.Data.Migrations
{
    /// <inheritdoc />
    public partial class Tarif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Tarif",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeTarif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEANCEID = table.Column<int>(type: "int", nullable: true),
                    NUET = table.Column<int>(type: "int", nullable: true),
                    NCINEMAID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarif", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarif_Cinema_NCINEMAID",
                        column: x => x.NCINEMAID,
                        principalTable: "Cinema",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Tarif_Seance_SEANCEID",
                        column: x => x.SEANCEID,
                        principalTable: "Seance",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Proposer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prix = table.Column<float>(type: "real", nullable: true),
                    SEANCEID = table.Column<int>(type: "int", nullable: true),
                    CinemaID = table.Column<int>(type: "int", nullable: false),
                    TaridID = table.Column<int>(type: "int", nullable: false),
                    TarifId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Proposer_Cinema_CinemaID",
                        column: x => x.CinemaID,
                        principalTable: "Cinema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proposer_Seance_SEANCEID",
                        column: x => x.SEANCEID,
                        principalTable: "Seance",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Proposer_Tarif_TarifId",
                        column: x => x.TarifId,
                        principalTable: "Tarif",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaSeance_SeancesID",
                table: "CinemaSeance",
                column: "SeancesID");

            migrationBuilder.CreateIndex(
                name: "IX_Proposer_CinemaID",
                table: "Proposer",
                column: "CinemaID");

            migrationBuilder.CreateIndex(
                name: "IX_Proposer_SEANCEID",
                table: "Proposer",
                column: "SEANCEID");

            migrationBuilder.CreateIndex(
                name: "IX_Proposer_TarifId",
                table: "Proposer",
                column: "TarifId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarif_NCINEMAID",
                table: "Tarif",
                column: "NCINEMAID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarif_SEANCEID",
                table: "Tarif",
                column: "SEANCEID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaSeance");

            migrationBuilder.DropTable(
                name: "Proposer");

            migrationBuilder.DropTable(
                name: "Tarif");
        }
    }
}
