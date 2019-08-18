using Newtonsoft.Json;

namespace I8Beef.Neato.Nucleo.Protocol
{
    /// <summary>
    /// Available commands.
    /// </summary>
    public class AvailableCommands
    {
        /// <summary>
        /// Start.
        /// </summary>
        [JsonProperty(PropertyName = "start")]
        public bool Start { get; set; }

        /// <summary>
        /// Stop.
        /// </summary>
        [JsonProperty(PropertyName = "stop")]
        public bool Stop { get; set; }

        /// <summary>
        /// Pause.
        /// </summary>
        [JsonProperty(PropertyName = "pause")]
        public bool Pause { get; set; }

        /// <summary>
        /// Resume.
        /// </summary>
        [JsonProperty(PropertyName = "resume")]
        public bool Resume { get; set; }

        /// <summary>
        /// Go to base.
        /// </summary>
        [JsonProperty(PropertyName = "goToBase")]
        public bool GoToBase { get; set; }
    }
}
