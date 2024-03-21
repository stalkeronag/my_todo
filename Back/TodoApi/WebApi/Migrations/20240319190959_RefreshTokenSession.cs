using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokenSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fingerprint",
                table: "refreshTokens");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "refreshTokens",
                newName: "Token");

            migrationBuilder.CreateTable(
                name: "refreshTokenSessions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    RefreshTokenId = table.Column<string>(type: "text", nullable: true),
                    Fingerprint = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refreshTokenSessions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "refreshTokenSessions");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "refreshTokens",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "Fingerprint",
                table: "refreshTokens",
                type: "text",
                nullable: true);
        }
    }
}
