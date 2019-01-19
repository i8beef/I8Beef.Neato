using System.Collections.Generic;
using Newtonsoft.Json;

namespace I8Beef.Neato.BeeHive.Protocol
{
    /// <summary>
    /// Maps information
    /// </summary>
    public class MapsInformation
    {
        /// <summary>
        /// Stats.
        /// </summary>
        [JsonProperty(PropertyName = "stats")]
        public StatsInformation Stats { get; set; }

        /// <summary>
        /// Maps.
        /// </summary>
        [JsonProperty(PropertyName = "maps")]
        public IList<MapInformation> Maps { get; set; }
    }
}
