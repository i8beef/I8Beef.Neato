﻿using Newtonsoft.Json;

namespace I8Beef.Neato.Nucleo.Protocol
{
    /// <summary>
    /// Cleaning information.
    /// </summary>
    public class CleaningInformation
    {
        /// <summary>
        /// Category.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public CleaningCategory Category { get; set; }

        /// <summary>
        /// Mode.
        /// </summary>
        [JsonProperty(PropertyName = "mode")]
        public CleaningMode Mode { get; set; }

        /// <summary>
        /// Modifier.
        /// </summary>
        [JsonProperty(PropertyName = "modifier")]
        public CleaningFrequency Modifier { get; set; }

        /// <summary>
        /// Navigation mode.
        /// </summary>
        [JsonProperty(PropertyName = "navigationMode")]
        public NavigationMode NavigationMode { get; set; }

        /// <summary>
        /// Spot width.
        /// </summary>
        [JsonProperty(PropertyName = "spotWidth")]
        public int SpotWidth { get; set; }

        /// <summary>
        /// Spot height.
        /// </summary>
        [JsonProperty(PropertyName = "spotHeight")]
        public int SpotHeight { get; set; }
    }
}
