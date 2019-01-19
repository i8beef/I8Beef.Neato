using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo.Services.Maps
{
    /// <summary>
    /// GetMapBoundaries.
    /// </summary>
    public class GetMapBoundaries
    {
        /// <summary>
        /// The unique persistent map id originally assigned by the robot.
        /// These id can be retrieved with the appropiate call to Beehive.
        /// </summary>
        [JsonProperty(PropertyName = "mapId")]
        public string MapId { get; set; }
    }
}
