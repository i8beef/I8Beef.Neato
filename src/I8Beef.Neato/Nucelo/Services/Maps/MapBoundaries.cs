using System.Collections.Generic;
using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo.Services.Maps
{
    /// <summary>
    /// Map boundaries.
    /// </summary>
    public class MapBoundaries
    {
        /// <summary>
        /// All the user-defined boundaries. Each element of the array defines one boundary.
        /// </summary>
        [JsonProperty(PropertyName = "boundaries")]
        public IList<Boundary> Boundaries { get; set; }
    }
}
