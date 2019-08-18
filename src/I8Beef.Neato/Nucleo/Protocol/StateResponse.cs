using Newtonsoft.Json;

namespace I8Beef.Neato.Nucleo.Protocol
{
    /// <summary>
    /// State response.
    /// </summary>
    /// <typeparam name="TData">Type of the Data element.</typeparam>
    public class StateResponse<TData> : StandardResponse<TData>
    {
        /// <summary>
        /// State.
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public StateType State { get; set; }

        /// <summary>
        /// Action.
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public ActionType Action { get; set; }

        /// <summary>
        /// Error.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public int? Error { get; set; }

        /// <summary>
        /// Alert.
        /// </summary>
        [JsonProperty(PropertyName = "alert")]
        public string Alert { get; set; }

        /// <summary>
        /// Cleaning information.
        /// </summary>
        [JsonProperty(PropertyName = "cleaning")]
        public CleaningInformation Cleaning { get; set; }

        /// <summary>
        /// Detail information.
        /// </summary>
        [JsonProperty(PropertyName = "details")]
        public DetailInformation Details { get; set; }

        /// <summary>
        /// Available commands.
        /// </summary>
        [JsonProperty(PropertyName = "availableCommands")]
        public AvailableCommands AvailableCommands { get; set; }

        /// <summary>
        /// Available services.
        /// </summary>
        [JsonProperty(PropertyName = "availableServices")]
        public AvailableServices AvailableServices { get; set; }

        /// <summary>
        /// Meta information.
        /// </summary>
        [JsonProperty(PropertyName = "meta")]
        public MetaInformation MetaInformation { get; set; }
    }
}
