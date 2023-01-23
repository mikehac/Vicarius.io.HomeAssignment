using Newtonsoft.Json;

namespace Vicarius.io.HomeAssignment.ResponseDtos
{
    public class Response
    {
        [JsonProperty("_index")]
        public string Index { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("_version")]
        public int Version { get; set; }

        [JsonProperty("_seq_no")]
        public int Seq_no { get; set; }

        [JsonProperty("_primary_term")]
        public int Primary_term { get; set; }
        [JsonProperty("found")]
        public bool Found { get; set; }
    }
}
