using DataModel.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataModel.Entities
{
    public class HeroRatingTeam : IEntity, IHasId
    {
        public int Id { get; set; }
        public int HeroId { get; set; }
        public int TeamHeroId { get; set; }
        public int ParsedMatches { get; set; }
        public double FantasyPoint { get; set; }

        public Hero Hero { get; set; }
        public Hero TeamHero { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroRatingTeam>(b =>
            {
                b.HasKey(x => x.Id);

                b.HasOne(x => x.Hero)
                    .WithMany(x => x.EnemyHeroes)
                    .HasForeignKey(x => x.HeroId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(x => x.TeamHero)
                    .WithMany(x => x.TeamHeroes)
                    .HasForeignKey(x => x.TeamHeroId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
