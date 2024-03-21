using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKeyFingerPrint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fingerprint",
                table: "refreshTokenSessions");

            migrationBuilder.AddColumn<string>(
                name: "RefreshTokenSessionId",
                table: "fingerPrints",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_fingerPrints_RefreshTokenSessionId",
                table: "fingerPrints",
                column: "RefreshTokenSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_fingerPrints_refreshTokenSessions_RefreshTokenSessionId",
                table: "fingerPrints",
                column: "RefreshTokenSessionId",
                principalTable: "refreshTokenSessions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fingerPrints_refreshTokenSessions_RefreshTokenSessionId",
                table: "fingerPrints");

            migrationBuilder.DropIndex(
                name: "IX_fingerPrints_RefreshTokenSessionId",
                table: "fingerPrints");

            migrationBuilder.DropColumn(
                name: "RefreshTokenSessionId",
                table: "fingerPrints");

            migrationBuilder.AddColumn<string>(
                name: "Fingerprint",
                table: "refreshTokenSessions",
                type: "text",
                nullable: true);
        }
    }
}
