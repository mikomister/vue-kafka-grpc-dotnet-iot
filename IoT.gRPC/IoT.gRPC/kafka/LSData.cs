using Newtonsoft.Json;

namespace IoT.gRPC.kafka
{
    public class LSData
    {
        [JsonRequired]
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonRequired]
        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
