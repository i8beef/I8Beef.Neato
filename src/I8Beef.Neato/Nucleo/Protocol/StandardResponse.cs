using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace I8Beef.Neato.Nucleo.Protocol
{
    /// <summary>
    /// Standard response.
    /// </summary>
    /// <typeparam name="TData">Type of the Data element.</typeparam>
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
        [JsonConverter(typeof(StringEnumConverter))]
        public ResultType Result { get; set; }

        /// <summary>
        /// Data.
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public TData Data { get; set; }
    }
}
