using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class RefreshSessionOnetoMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_refreshTokenSessions_refreshTokens_RefreshTokenId",
                table: "refreshTokenSessions");

            migrationBuilder.DropIndex(
                name: "IX_refreshTokenSessions_RefreshTokenId",
                table: "refreshTokenSessions");

            migrationBuilder.AddColumn<string>(
                name: "RefreshTokenSessionId",
                table: "refreshTokens",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_refreshTokenSessions_UserId",
                table: "refreshTokenSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_refreshTokens_RefreshTokenSessionId",
                table: "refreshTokens",
                column: "RefreshTokenSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_refreshTokens_refreshTokenSessions_RefreshTokenSessionId",
                table: "refreshTokens",
                column: "RefreshTokenSessionId",
                principalTable: "refreshTokenSessions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_refreshTokenSessions_AspNetUsers_UserId",
                table: "refreshTokenSessions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_refreshTokens_refreshTokenSessions_RefreshTokenSessionId",
                table: "refreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_refreshTokenSessions_AspNetUsers_UserId",
                table: "refreshTokenSessions");

            migrationBuilder.DropIndex(
                name: "IX_refreshTokenSessions_UserId",
                table: "refreshTokenSessions");

            migrationBuilder.DropIndex(
                name: "IX_refreshTokens_RefreshTokenSessionId",
                table: "refreshTokens");

            migrationBuilder.DropColumn(
                name: "RefreshTokenSessionId",
                table: "refreshTokens");

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
    }
}
