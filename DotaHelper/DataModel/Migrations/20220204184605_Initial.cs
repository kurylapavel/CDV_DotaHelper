using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataModel.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeroName = table.Column<string>(type: "text", nullable: true),
                    AverageKDA = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    MatchesCount = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParsedMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastParsedMatchId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    ParsedMatchesCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParsedMatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroRatingTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeroId = table.Column<int>(type: "integer", nullable: false),
                    TeamHeroId = table.Column<int>(type: "integer", nullable: false),
                    ParsedMatches = table.Column<int>(type: "integer", nullable: false),
                    FantasyPoint = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroRatingTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeroRatingTeam_Hero_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Hero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroRatingTeam_Hero_TeamHeroId",
                        column: x => x.TeamHeroId,
                        principalTable: "Hero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroRatingTeam_HeroId",
                table: "HeroRatingTeam",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroRatingTeam_TeamHeroId",
                table: "HeroRatingTeam",
                column: "TeamHeroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroRatingTeam");

            migrationBuilder.DropTable(
                name: "ParsedMatches");

            migrationBuilder.DropTable(
                name: "Hero");
        }
    }
}
