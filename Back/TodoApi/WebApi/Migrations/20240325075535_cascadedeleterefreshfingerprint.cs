using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class cascadedeleterefreshfingerprint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_refreshTokenFingerprints_refreshTokens_RefreshTokenId",
                table: "refreshTokenFingerprints");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshTokenId",
                table: "refreshTokenFingerprints",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_refreshTokenFingerprints_refreshTokens_RefreshTokenId",
                table: "refreshTokenFingerprints",
                column: "RefreshTokenId",
                principalTable: "refreshTokens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_refreshTokenFingerprints_refreshTokens_RefreshTokenId",
                table: "refreshTokenFingerprints");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshTokenId",
                table: "refreshTokenFingerprints",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_refreshTokenFingerprints_refreshTokens_RefreshTokenId",
                table: "refreshTokenFingerprints",
                column: "RefreshTokenId",
                principalTable: "refreshTokens",
                principalColumn: "Id");
        }
    }
}
