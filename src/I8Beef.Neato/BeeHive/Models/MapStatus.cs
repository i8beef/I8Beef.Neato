using System.Runtime.Serialization;

namespace I8Beef.Neato.BeeHive.Models
{
    /// <summary>
    /// Map status.
    /// </summary>
    public enum MapStatus
    {
        /// <summary>
        /// Incomplete.
        /// </summary>
        [EnumMember(Value = "incomplete")]
        Incomplete,

        /// <summary>
        /// Complete.
        /// </summary>
        [EnumMember(Value = "complete")]
        Complete,

        /// <summary>
        /// Canceled.
        /// </summary>
        [EnumMember(Value = "canceled")]
        Canceled
    }
}
