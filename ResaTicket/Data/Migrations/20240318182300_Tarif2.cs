using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResaTicket.Data.Migrations
{
    /// <inheritdoc />
    public partial class Tarif2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposer_Tarif_TarifId",
                table: "Proposer");

            migrationBuilder.DropColumn(
                name: "TaridID",
                table: "Proposer");

            migrationBuilder.RenameColumn(
                name: "TarifId",
                table: "Proposer",
                newName: "TarifID");

            migrationBuilder.RenameIndex(
                name: "IX_Proposer_TarifId",
                table: "Proposer",
                newName: "IX_Proposer_TarifID");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposer_Tarif_TarifID",
                table: "Proposer",
                column: "TarifID",
                principalTable: "Tarif",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposer_Tarif_TarifID",
                table: "Proposer");

            migrationBuilder.RenameColumn(
                name: "TarifID",
                table: "Proposer",
                newName: "TarifId");

            migrationBuilder.RenameIndex(
                name: "IX_Proposer_TarifID",
                table: "Proposer",
                newName: "IX_Proposer_TarifId");

            migrationBuilder.AddColumn<int>(
                name: "TaridID",
                table: "Proposer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Proposer_Tarif_TarifId",
                table: "Proposer",
                column: "TarifId",
                principalTable: "Tarif",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
