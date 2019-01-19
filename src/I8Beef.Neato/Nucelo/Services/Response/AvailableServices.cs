using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo.Services.Response
{
    /// <summary>
    /// Available services.
    /// </summary>
    public class AvailableServices
    {
        /// <summary>
        /// Find me.
        /// </summary>
        [JsonProperty(PropertyName = "findMe")]
        public string FindMe { get; set; }

        /// <summary>
        /// General info.
        /// </summary>
        [JsonProperty(PropertyName = "generalInfo")]
        public string GeneralInfo { get; set; }

        /// <summary>
        /// House cleaning.
        /// </summary>
        [JsonProperty(PropertyName = "houseCleaning")]
        public string HouseCleaning { get; set; }

        /// <summary>
        /// Local stats.
        /// </summary>
        [JsonProperty(PropertyName = "localStats")]
        public string LocalStats { get; set; }

        /// <summary>
        /// Manual cleaning.
        /// </summary>
        [JsonProperty(PropertyName = "manualCleaning")]
        public string ManualCleaning { get; set; }

        /// <summary>
        /// Maps.
        /// </summary>
        [JsonProperty(PropertyName = "maps")]
        public string Maps { get; set; }

        /// <summary>
        /// Preferences.
        /// </summary>
        [JsonProperty(PropertyName = "preferences")]
        public string Preferences { get; set; }

        /// <summary>
        /// Schedule.
        /// </summary>
        [JsonProperty(PropertyName = "schedule")]
        public string Schedule { get; set; }

        /// <summary>
        /// Spot cleaning.
        /// </summary>
        [JsonProperty(PropertyName = "spotCleaning")]
        public string SpotCleaning { get; set; }
    }
}
