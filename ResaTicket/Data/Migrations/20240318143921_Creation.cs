using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResaTicket.Data.Migrations
{
    /// <inheritdoc />
    public partial class Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinema",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num_rue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code_Postal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comp_Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIRET = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RIB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Statut = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinema", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Langue",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeLangue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langue", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TypeDiffusion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDiffusion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Realisateur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acteur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LangueID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Film_Langue_LangueID",
                        column: x => x.LangueID,
                        principalTable: "Langue",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Film_Langue",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmID = table.Column<int>(type: "int", nullable: true),
                    LangueID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film_Langue", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Film_Langue_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Film_Langue_Langue_LangueID",
                        column: x => x.LangueID,
                        principalTable: "Langue",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Seance",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroSalle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateJour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmID = table.Column<int>(type: "int", nullable: true),
                    TypeDiffusionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Seance_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Seance_TypeDiffusion_TypeDiffusionID",
                        column: x => x.TypeDiffusionID,
                        principalTable: "TypeDiffusion",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Film_LangueID",
                table: "Film",
                column: "LangueID");

            migrationBuilder.CreateIndex(
                name: "IX_Film_Langue_FilmID",
                table: "Film_Langue",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_Film_Langue_LangueID",
                table: "Film_Langue",
                column: "LangueID");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_FilmID",
                table: "Seance",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_TypeDiffusionID",
                table: "Seance",
                column: "TypeDiffusionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cinema");

            migrationBuilder.DropTable(
                name: "Film_Langue");

            migrationBuilder.DropTable(
                name: "Seance");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "TypeDiffusion");

            migrationBuilder.DropTable(
                name: "Langue");
        }
    }
}
