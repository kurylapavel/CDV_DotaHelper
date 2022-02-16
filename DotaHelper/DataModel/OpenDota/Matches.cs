using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataModel.OpenDota
{
    public class Matches
    {
        [JsonProperty("match_id")]
        public string MatchId { get; set; }

        [JsonProperty("radiant_win")]
        public bool RadiantWin { get; set; }

        [JsonProperty("players")]
        public List<Player> Players { get; set; }
    }
}
