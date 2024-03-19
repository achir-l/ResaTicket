using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResaTicket.Data.Migrations
{
    /// <inheritdoc />
    public partial class TypePaiement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypePaiement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePaiement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CinemaPaiement",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaID = table.Column<int>(type: "int", nullable: true),
                    TypePaiementID = table.Column<int>(type: "int", nullable: true),
                    TTypePaiementID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaPaiement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CinemaPaiement_Cinema_CinemaID",
                        column: x => x.CinemaID,
                        principalTable: "Cinema",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CinemaPaiement_Langue_TTypePaiementID",
                        column: x => x.TTypePaiementID,
                        principalTable: "Langue",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CinemaPaiement_TypePaiement_TypePaiementID",
                        column: x => x.TypePaiementID,
                        principalTable: "TypePaiement",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaPaiement_CinemaID",
                table: "CinemaPaiement",
                column: "CinemaID");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaPaiement_TTypePaiementID",
                table: "CinemaPaiement",
                column: "TTypePaiementID");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaPaiement_TypePaiementID",
                table: "CinemaPaiement",
                column: "TypePaiementID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaPaiement");

            migrationBuilder.DropTable(
                name: "TypePaiement");
        }
    }
}
