using System.Collections.Generic;
using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo.Services.Schedule
{
    /// <summary>
    /// Schedule.
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// <c>true</c> if enabled, otherwise <c>false</c>.
        /// </summary>
        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Schedule type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public ScheduleType Type { get; set; } = ScheduleType.Default;

        /// <summary>
        /// An array of schedule events.
        /// </summary>
        [JsonProperty(PropertyName = "events")]
        public IList<ScheduleEvent> Events { get; set; }
    }
}
