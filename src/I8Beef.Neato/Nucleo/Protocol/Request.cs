using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace I8Beef.Neato.Nucleo.Protocol
{
    /// <summary>
    /// Nucelo Request.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <param name="requestId">Request id.</param>
        /// <param name="command">Command type.</param>
        /// <param name="parameters">Parameters object.</param>
        public Request(int requestId, CommandType command, object parameters)
        {
            RequestId = requestId.ToString();
            Command = command;
            Parameters = parameters;
        }

        /// <summary>
        /// Request ID.
        /// </summary>
        [JsonProperty(PropertyName = "reqId")]
        public string RequestId { get; private set; }

        /// <summary>
        /// Command.
        /// </summary>
        [JsonProperty(PropertyName = "cmd")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CommandType Command { get; private set; }

        /// <summary>
        /// Parameters.
        /// </summary>
        [JsonProperty(PropertyName = "params")]
        public object Parameters { get; private set; }
    }
}
