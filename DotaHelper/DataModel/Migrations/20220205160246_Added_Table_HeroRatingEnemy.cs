using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataModel.Migrations
{
    public partial class Added_Table_HeroRatingEnemy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeroRatingEnemy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeroId = table.Column<int>(type: "integer", nullable: false),
                    EnemyHeroId = table.Column<int>(type: "integer", nullable: false),
                    ParsedMatches = table.Column<int>(type: "integer", nullable: false),
                    FantasyPoint = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroRatingEnemy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeroRatingEnemy_Hero_EnemyHeroId",
                        column: x => x.EnemyHeroId,
                        principalTable: "Hero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroRatingEnemy_Hero_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Hero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroRatingEnemy_EnemyHeroId",
                table: "HeroRatingEnemy",
                column: "EnemyHeroId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroRatingEnemy_HeroId",
                table: "HeroRatingEnemy",
                column: "HeroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroRatingEnemy");
        }
    }
}
