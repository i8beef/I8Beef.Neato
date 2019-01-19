using System;
using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo.Protocol.Services.Schedule
{
    /// <summary>
    /// Schedule event.
    /// </summary>
    public class ScheduleEvent
    {
        /// <summary>
        /// Boundary of zone to clean.
        /// </summary>
        [JsonProperty(PropertyName = "boundary")]
        public string Boundary { get; set; }

        /// <summary>
        /// If provided, the ID of the zone to clean.
        /// </summary>
        [JsonProperty(PropertyName = "boundaryId")]
        public string BoundaryId { get; set; }

        /// <summary>
        /// The day of the week.
        /// </summary>
        [JsonProperty(PropertyName = "day")]
        public DayOfWeek Day { get; set; }

        /// <summary>
        /// The map id.
        /// </summary>
        [JsonProperty(PropertyName = "mapId")]
        public string MapId { get; set; }

        /// <summary>
        /// The cleaning mode.
        /// </summary>
        [JsonProperty(PropertyName = "mode")]
        public CleaningMode Mode { get; set; } = CleaningMode.Eco;

        /// <summary>
        /// The start time expressed in HH:MM.
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public string StartTime { get; set; }
    }
}
