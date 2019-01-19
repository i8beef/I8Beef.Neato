using System.Collections.Generic;
using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo.Services.LocalStats
{
    /// <summary>
    /// House cleaning.
    /// </summary>
    public class CleaningStats
    {
        /// <summary>
        /// Total cleaned area in the robot's lifetime (in square meters).
        /// </summary>
        [JsonProperty(PropertyName = "totalCleanedArea")]
        public decimal TotalCleanedArea { get; set; }

        /// <summary>
        /// Total time in the robot's lifetime (in seconds).
        /// </summary>
        [JsonProperty(PropertyName = "totalCleaningTime")]
        public decimal TotalCleaningTime { get; set; }

        /// <summary>
        /// Average cleaned area in the robot's lifetime (in square meters).
        /// </summary>
        [JsonProperty(PropertyName = "averageCleanedArea")]
        public decimal AverageCleanedArea { get; set; }

        /// <summary>
        /// Average time in the robot's lifetime (in seconds).
        /// </summary>
        [JsonProperty(PropertyName = "averageCleaningTime")]
        public int AverageCleaningTime { get; set; }

        /// <summary>
        /// contains the last N cleaning events for a specific category. The elements are stored in descending order,
        /// the most recent item is the top most element of the array.
        /// </summary>
        [JsonProperty(PropertyName = "history")]
        public IList<History> History { get; set; }
    }
}
