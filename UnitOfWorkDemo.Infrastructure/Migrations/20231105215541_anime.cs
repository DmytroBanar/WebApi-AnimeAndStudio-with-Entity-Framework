using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UnitOfWorkDemo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class anime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    StudioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudioName = table.Column<string>(type: "text", nullable: false),
                    StudioCountry = table.Column<string>(type: "text", nullable: false),
                    StudioNumProjects = table.Column<int>(type: "integer", nullable: false),
                    StudioMPWork = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.StudioId);
                });

            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    AnimeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimeName = table.Column<string>(type: "text", nullable: false),
                    AnimeScore = table.Column<float>(type: "real", nullable: false),
                    AnimeEpisodes = table.Column<int>(type: "integer", nullable: false),
                    AnimeType = table.Column<string>(type: "text", nullable: false),
                    AnimeAuthor = table.Column<string>(type: "text", nullable: false),
                    AnimeStudioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.AnimeId);
                    table.ForeignKey(
                        name: "FK_Animes_Studios_AnimeStudioId",
                        column: x => x.AnimeStudioId,
                        principalTable: "Studios",
                        principalColumn: "StudioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animes_AnimeStudioId",
                table: "Animes",
                column: "AnimeStudioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
