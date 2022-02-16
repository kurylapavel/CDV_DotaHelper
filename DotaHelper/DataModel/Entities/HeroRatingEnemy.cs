using DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Entities
{
    public class HeroRatingEnemy : IEntity, IHasId
    {
        public int Id { get; set; }
        public int HeroId { get; set; }
        public int EnemyHeroId { get; set; }
        public int ParsedMatches { get; set; }
        public double FantasyPoint { get; set; }

        public Hero Hero { get; set; }
        public Hero TeamHero { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroRatingEnemy>(b =>
            {
                b.HasKey(x => x.Id);

                b.HasOne(x => x.Hero)
                    .WithMany(x => x.TeamHeroesEnemy)
                    .HasForeignKey(x => x.HeroId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(x => x.TeamHero)
                    .WithMany(x => x.EnemyHeroesEnemy)
                    .HasForeignKey(x => x.EnemyHeroId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
