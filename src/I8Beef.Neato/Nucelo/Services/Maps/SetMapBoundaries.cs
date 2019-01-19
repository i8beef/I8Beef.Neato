using System.Collections.Generic;
using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo.Services.Maps
{
    /// <summary>
    /// SetMapBoundaries.
    /// </summary>
    public class SetMapBoundaries
    {
        /// <summary>
        /// The unique persistent map id originally assigned by the robot.
        /// These id can be retrieved with the appropiate call to Beehive.
        /// </summary>
        [JsonProperty(PropertyName = "mapId")]
        public string MapId { get; set; }

        /// <summary>
        /// All the user-defined boundaries. Each element of the array defines one boundary.
        /// </summary>
        [JsonProperty(PropertyName = "boundaries")]
        public IList<Boundary> Boundaries { get; set; }
    }
}
