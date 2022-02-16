using DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Entities
{
    public class Hero : IEntity, IHasId
    {
        public int Id { get; set; }

        [JsonProperty("localized_name")]
        public string HeroName { get; set; }
        public double AverageKDA { get; set; }
        public int MatchesCount { get; set; }

        public List<HeroRatingTeam> EnemyHeroes { get; set; }
        public List<HeroRatingTeam> TeamHeroes { get; set; }

        public List<HeroRatingEnemy> EnemyHeroesEnemy { get; set; }
        public List<HeroRatingEnemy> TeamHeroesEnemy { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>(b =>
            {
                b.HasKey(x => x.Id);

                b.Property(x => x.AverageKDA)
                    .HasDefaultValue(0D);

                b.Property(x => x.MatchesCount)
                    .HasDefaultValue(0);
            });
        }
    }
}
