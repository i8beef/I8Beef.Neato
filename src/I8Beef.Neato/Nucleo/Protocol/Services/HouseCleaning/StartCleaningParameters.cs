using Newtonsoft.Json;

namespace I8Beef.Neato.Nucleo.Protocol.Services.HouseCleaning
{
    /// <summary>
    /// Start cleaning.
    /// </summary>
    public class StartCleaningParameters
    {
        /// <summary>
        /// Boundary id.
        /// </summary>
        [JsonProperty(PropertyName = "boundaryId")]
        public string BoundaryId { get; set; }

        /// <summary>
        /// Category.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public CleaningCategory Category { get; set; } = CleaningCategory.HouseCleaning;

        /// <summary>
        /// Mode.
        /// </summary>
        [JsonProperty(PropertyName = "mode")]
        public CleaningMode Mode { get; set; } = CleaningMode.Eco;

        /// <summary>
        /// Modifier.
        /// </summary>
        [JsonProperty(PropertyName = "modifier")]
        public CleaningFrequency Modifier { get; set; } = CleaningFrequency.Normal;

        /// <summary>
        /// NavigationMode.
        /// </summary>
        [JsonProperty(PropertyName = "navigationMode")]
        public NavigationMode NavigationMode { get; set; } = NavigationMode.Normal;

        /// <summary>
        /// SpotHeight.
        /// </summary>
        [JsonProperty(PropertyName = "spotHeight")]
        public int? SpotHeight { get; set; }

        /// <summary>
        /// SpotWidth.
        /// </summary>
        [JsonProperty(PropertyName = "spotWidth")]
        public int? SpotWidth { get; set; }
    }
}
