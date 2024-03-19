using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResaTicket.Data.Migrations
{
    /// <inheritdoc />
    public partial class TypePaiement2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaPaiement_Langue_TTypePaiementID",
                table: "CinemaPaiement");

            migrationBuilder.DropIndex(
                name: "IX_CinemaPaiement_TTypePaiementID",
                table: "CinemaPaiement");

            migrationBuilder.DropColumn(
                name: "TTypePaiementID",
                table: "CinemaPaiement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TTypePaiementID",
                table: "CinemaPaiement",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CinemaPaiement_TTypePaiementID",
                table: "CinemaPaiement",
                column: "TTypePaiementID");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaPaiement_Langue_TTypePaiementID",
                table: "CinemaPaiement",
                column: "TTypePaiementID",
                principalTable: "Langue",
                principalColumn: "ID");
        }
    }
}
