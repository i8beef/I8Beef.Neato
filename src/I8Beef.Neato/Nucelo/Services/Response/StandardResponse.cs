using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo.Services.Response
{
    /// <summary>
    /// Standard response.
    /// </summary>
    public class StandardResponse<TData>
    {
        /// <summary>
        /// Version.
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        /// <summary>
        /// Request ID.
        /// </summary>
        [JsonProperty(PropertyName = "reqId")]
        public string RequestId { get; set; }

        /// <summary>
        /// Result.
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public ResultType Result { get; set; }

        /// <summary>
        /// Data.
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public TData Data { get; set; }
    }
}
