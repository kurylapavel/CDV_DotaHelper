using DataModel.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataModel.Entities
{
    public class ParsedMatches : IEntity, IHasId
    {
        public int Id { get; set; }

        public ulong LastParsedMatchId { get; set; }
        
        public int ParsedMatchesCount { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParsedMatches>(b =>
            {

            });
        }
    }
}
