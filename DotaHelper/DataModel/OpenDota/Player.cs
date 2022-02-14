using Newtonsoft.Json;

namespace DataModel.OpenDota
{
    public class Player
    {
        [JsonProperty("assists")]
        public string Assists { get; set; }

        [JsonProperty("deaths")]
        public string Deaths { get; set; }

        [JsonProperty("kills")]
        public string Kills { get; set; }

        [JsonProperty("hero_id")]
        public string HeroId { get; set; }
    }
}
