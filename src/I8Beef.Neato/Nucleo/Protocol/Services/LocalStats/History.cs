using System;
using Newtonsoft.Json;

namespace I8Beef.Neato.Nucleo.Protocol.Services.LocalStats
{
    /// <summary>
    /// History.
    /// </summary>
    public class History
    {
        /// <summary>
        /// The ISO8601 formatted GMT date and time stating when the cleaning event started.
        /// </summary>
        [JsonProperty(PropertyName = "start")]
        public DateTime Start { get; set; }

        /// <summary>
        /// The ISO8601 formatted GMT date and time stating when the cleaning event ended..
        /// </summary>
        [JsonProperty(PropertyName = "end")]
        public DateTime End { get; set; }

        /// <summary>
        /// The minutes the robot was on dock charging, during the last cleaning cycle.
        /// </summary>
        [JsonProperty(PropertyName = "suspendedCleaningChargingTime")]
        public int SuspendedCleaningChargingTime { get; set; }

        /// <summary>
        /// The seconds the robot was on error state, during the last cleaning cycle.
        /// </summary>
        [JsonProperty(PropertyName = "errorTime")]
        public int ErrorTime { get; set; }

        /// <summary>
        /// The seconds the robot was on pause state, during the last cleaning cycle.
        /// </summary>
        [JsonProperty(PropertyName = "pauseTime")]
        public int PauseTime { get; set; }

        /// <summary>
        /// The cleaning mode.
        /// </summary>
        [JsonProperty(PropertyName = "mode")]
        public CleaningMode Mode { get; set; }

        /// <summary>
        /// The area cleaned during this cleaning event.
        /// </summary>
        [JsonProperty(PropertyName = "moareade")]
        public decimal Area { get; set; }

        /// <summary>
        /// Defines if the cleaning event has been lanched from robot, schedule or app.
        /// </summary>
        [JsonProperty(PropertyName = "launchedFrom")]
        public string LaunchedFrom { get; set; }

        /// <summary>
        /// <c>true</c> if the cleaning event successfully completes. <c>false</c> otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "completed")]
        public bool Completed { get; set; }
    }
}
