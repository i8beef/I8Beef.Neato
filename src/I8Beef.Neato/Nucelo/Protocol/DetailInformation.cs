using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo.Protocol
{
    /// <summary>
    /// Detail information.
    /// </summary>
    public class DetailInformation
    {
        /// <summary>
        /// Is charging.
        /// </summary>
        [JsonProperty(PropertyName = "isCharging")]
        public bool IsCharging { get; set; }

        /// <summary>
        /// Is docked.
        /// </summary>
        [JsonProperty(PropertyName = "isDocked")]
        public bool IsDocked { get; set; }

        /// <summary>
        /// Dock has been seen.
        /// </summary>
        [JsonProperty(PropertyName = "dockHasBeenSeen")]
        public bool DockHasBeenSeen { get; set; }

        /// <summary>
        /// Charge.
        /// </summary>
        [JsonProperty(PropertyName = "charge")]
        public int Charge { get; set; }

        /// <summary>
        /// Is schedule enabled.
        /// </summary>
        [JsonProperty(PropertyName = "isScheduleEnabled")]
        public bool IsScheduleEnabled { get; set; }
    }
}
