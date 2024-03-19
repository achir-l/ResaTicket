using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResaTicket.Data.Migrations
{
    /// <inheritdoc />
    public partial class Cinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarif_Cinema_NCINEMAID",
                table: "Tarif");

            migrationBuilder.DropIndex(
                name: "IX_Tarif_NCINEMAID",
                table: "Tarif");

            migrationBuilder.DropColumn(
                name: "NCINEMAID",
                table: "Tarif");

            migrationBuilder.RenameColumn(
                name: "NUET",
                table: "Tarif",
                newName: "CINEMAID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarif_CINEMAID",
                table: "Tarif",
                column: "CINEMAID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarif_Cinema_CINEMAID",
                table: "Tarif",
                column: "CINEMAID",
                principalTable: "Cinema",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarif_Cinema_CINEMAID",
                table: "Tarif");

            migrationBuilder.DropIndex(
                name: "IX_Tarif_CINEMAID",
                table: "Tarif");

            migrationBuilder.RenameColumn(
                name: "CINEMAID",
                table: "Tarif",
                newName: "NUET");

            migrationBuilder.AddColumn<int>(
                name: "NCINEMAID",
                table: "Tarif",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarif_NCINEMAID",
                table: "Tarif",
                column: "NCINEMAID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarif_Cinema_NCINEMAID",
                table: "Tarif",
                column: "NCINEMAID",
                principalTable: "Cinema",
                principalColumn: "ID");
        }
    }
}
