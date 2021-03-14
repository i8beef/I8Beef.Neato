using System.Runtime.Serialization;

namespace I8Beef.Neato.Nucleo.Protocol.Services.Maps
{
    /// <summary>
    /// Boundary type.
    /// </summary>
    public enum BoundaryType
    {
        /// <summary>
        /// A non crossable polyline such as one or multiple jointed mag strip (such as a Z-shaped element).
        /// </summary>
        [EnumMember(Value = "polyline")]
        Polyline,

        /// <summary>
        /// A n-polygon that defines a go-zone area (such as the kitchen).
        /// </summary>
        [EnumMember(Value = "polygon")]
        Polygon
    }
}
