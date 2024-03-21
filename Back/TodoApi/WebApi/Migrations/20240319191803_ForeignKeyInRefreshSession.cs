using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyInRefreshSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_refreshTokenSessions_RefreshTokenId",
                table: "refreshTokenSessions",
                column: "RefreshTokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_refreshTokenSessions_refreshTokens_RefreshTokenId",
                table: "refreshTokenSessions",
                column: "RefreshTokenId",
                principalTable: "refreshTokens",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_refreshTokenSessions_refreshTokens_RefreshTokenId",
                table: "refreshTokenSessions");

            migrationBuilder.DropIndex(
                name: "IX_refreshTokenSessions_RefreshTokenId",
                table: "refreshTokenSessions");
        }
    }
}
