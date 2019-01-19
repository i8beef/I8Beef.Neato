using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo.Protocol.Services.Maps
{
    /// <summary>
    /// Boundary.
    /// </summary>
    public class Boundary
    {
        /// <summary>
        /// The hex color value of the boundary. May be empty.
        /// </summary>
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        /// <summary>
        /// Whether or not the boundary is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The friendly identifier name of the boundary. May be empty.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Boundary type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public BoundaryType Type { get; set; } = BoundaryType.Polyline;

        /// <summary>
        /// Vertices.
        /// </summary>
        [JsonProperty(PropertyName = "vertices")]
        public IList<IList<Decimal>> Vertices { get; set; }
    }
}
