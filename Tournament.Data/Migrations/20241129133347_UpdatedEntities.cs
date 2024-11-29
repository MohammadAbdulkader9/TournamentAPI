using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tournament.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_TournamentDetails_tournamentDetailsId",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "tournamentDetailsId",
                table: "Game",
                newName: "TournamentDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_tournamentDetailsId",
                table: "Game",
                newName: "IX_Game_TournamentDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_TournamentDetails_TournamentDetailsId",
                table: "Game",
                column: "TournamentDetailsId",
                principalTable: "TournamentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_TournamentDetails_TournamentDetailsId",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "TournamentDetailsId",
                table: "Game",
                newName: "tournamentDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_TournamentDetailsId",
                table: "Game",
                newName: "IX_Game_tournamentDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_TournamentDetails_tournamentDetailsId",
                table: "Game",
                column: "tournamentDetailsId",
                principalTable: "TournamentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
