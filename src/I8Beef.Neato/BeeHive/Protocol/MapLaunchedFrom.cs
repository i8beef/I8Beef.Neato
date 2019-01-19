using System.Runtime.Serialization;

namespace I8Beef.Neato.BeeHive.Protocol
{
    /// <summary>
    /// Map launched from.
    /// </summary>
    public enum MapLaunchedFrom
    {
        /// <summary>
        /// Robot.
        /// </summary>
        [EnumMember(Value = "robot")]
        Robot,

        /// <summary>
        /// Schedule.
        /// </summary>
        [EnumMember(Value = "schedule")]
        Schedule,

        /// <summary>
        /// App.
        /// </summary>
        [EnumMember(Value = "app")]
        App
    }
}
