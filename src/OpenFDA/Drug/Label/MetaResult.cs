using Newtonsoft.Json;

namespace OpenFDA.Drug.Label
{
    public class MetaResult
    {
        [JsonProperty("skip")]
        public long Skip { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }
}