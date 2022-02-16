using Newtonsoft.Json;

namespace DataModel.OpenDota
{
    public class Heroes
    {
        [JsonProperty("hero_id")]
        public string HeroId { get; set; }
    }
}
