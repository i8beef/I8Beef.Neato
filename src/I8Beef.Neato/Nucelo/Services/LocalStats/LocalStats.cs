using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo.Services.LocalStats
{
    /// <summary>
    /// Local stats.
    /// </summary>
    public class LocalStats
    {
        /// <summary>
        /// HouseCleaning.
        /// </summary>
        [JsonProperty(PropertyName = "houseCleaning")]
        public CleaningStats HouseCleaning { get; set; }

        /// <summary>
        /// SpotCleaning.
        /// </summary>
        [JsonProperty(PropertyName = "spotCleaning")]
        public CleaningStats SpotCleaning { get; set; }
    }
}
