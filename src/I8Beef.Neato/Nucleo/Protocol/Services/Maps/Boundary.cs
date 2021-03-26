using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace I8Beef.Neato.Nucleo.Protocol.Services.Maps
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
        public IList<IList<decimal>> Vertices { get; set; }

        /// <summary>
        /// This element MUST be present only if type is polygon. It gives the coordinates of a point inside the polygon with format [x,y] where x is the horizontal axis and y the vertical axis expressed as the fraction of respectively the width and the height of the map.
        /// A polygon may intersect walls, and hence cover areas of different and eventually non-adjacent rooms. Relevancy is the point that defines the area of interest as the set of all floor points that are contiguous to this point and are contained in the polygon.
        /// </summary>
        [JsonProperty(PropertyName = "relevancy")]
        public IList<decimal> Relevancy { get; set; }
    }
}
