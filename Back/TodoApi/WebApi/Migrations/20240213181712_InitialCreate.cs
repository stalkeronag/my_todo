using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles_info",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("roles_pk", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    email = table.Column<string>(type: "character varying", nullable: false),
                    hash_pass = table.Column<string>(type: "character varying", nullable: false),
                    phone = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pk", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "fk_role",
                        column: x => x.role_id,
                        principalTable: "roles_info",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_roles_role_id",
                table: "roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_roles_user_id",
                table: "roles",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "roles_info");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
