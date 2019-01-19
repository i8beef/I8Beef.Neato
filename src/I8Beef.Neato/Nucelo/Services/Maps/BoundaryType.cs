using System.Runtime.Serialization;

namespace I8Beef.Neato.Nucelo.Services.Maps
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
    }
}
