using System.Runtime.Serialization;

namespace I8Beef.Neato.Nucelo.Services.Request
{
    /// <summary>
    /// Command type.
    /// </summary>
    public enum CommandType
    {
        /// <summary>
        /// DismissCurrentAlert.
        /// </summary>
        [EnumMember(Value = "dismissCurrentAlert")]
        DismissCurrentAlert,

        /// <summary>
        /// FindMe.
        /// </summary>
        [EnumMember(Value = "findMe")]
        FindMe,

        /// <summary>
        /// GetGeneralInfo.
        /// </summary>
        [EnumMember(Value = "getGeneralInfo")]
        GetGeneralInfo,

        /// <summary>
        /// GetRobotInfo.
        /// </summary>
        [EnumMember(Value = "getRobotInfo")]
        GetRobotInfo,

        /// <summary>
        /// GetRobotState.
        /// </summary>
        [EnumMember(Value = "getRobotState")]
        GetRobotState,

        /// <summary>
        /// StartCleaning.
        /// </summary>
        [EnumMember(Value = "startCleaning")]
        StartCleaning,

        /// <summary>
        /// StopCleaning.
        /// </summary>
        [EnumMember(Value = "stopCleaning")]
        StopCleaning,

        /// <summary>
        /// PauseCleaning.
        /// </summary>
        [EnumMember(Value = "pauseCleaning")]
        PauseCleaning,

        /// <summary>
        /// ResumeCleaning.
        /// </summary>
        [EnumMember(Value = "resumeCleaning")]
        ResumeCleaning,

        /// <summary>
        /// SendToBase.
        /// </summary>
        [EnumMember(Value = "sendToBase")]
        SendToBase,

        /// <summary>
        /// GetLocalStats.
        /// </summary>
        [EnumMember(Value = "getLocalStats")]
        GetLocalStats,

        /// <summary>
        /// GetRobotManualCleaningInfo.
        /// </summary>
        [EnumMember(Value = "getRobotManualCleaningInfo")]
        GetRobotManualCleaningInfo,

        /// <summary>
        /// GetMapBoundaries.
        /// </summary>
        [EnumMember(Value = "getMapBoundaries")]
        GetMapBoundaries,

        /// <summary>
        /// SetMapBoundaries.
        /// </summary>
        [EnumMember(Value = "setMapBoundaries")]
        SetMapBoundaries,

        /// <summary>
        /// SetPreferences.
        /// </summary>
        [EnumMember(Value = "setPreferences")]
        SetPreferences,

        /// <summary>
        /// GetPreferences.
        /// </summary>
        [EnumMember(Value = "getPreferences")]
        GetPreferences,

        /// <summary>
        /// SetSchedule.
        /// </summary>
        [EnumMember(Value = "setSchedule")]
        SetSchedule,

        /// <summary>
        /// GetSchedule.
        /// </summary>
        [EnumMember(Value = "getSchedule")]
        GetSchedule,

        /// <summary>
        /// EnableSchedule.
        /// </summary>
        [EnumMember(Value = "enableSchedule")]
        EnableSchedule,

        /// <summary>
        /// DisableSchedule.
        /// </summary>
        [EnumMember(Value = "disableSchedule")]
        DisableSchedule
    }
}
