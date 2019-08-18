using System;
using I8Beef.Neato.Nucleo.Protocol;
using Newtonsoft.Json;

namespace I8Beef.Neato.BeeHive.Protocol
{
    /// <summary>
    /// Map information.
    /// </summary>
    public class MapInformation
    {
        /// <summary>
        /// The map format version.
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        /// <summary>
        /// The map identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The temporary map url.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The expiration time (in seconds) of the url.
        /// </summary>
        [JsonProperty(PropertyName = "url_valid_for_seconds")]
        public int UrlValidForSeconds { get; set; }

        /// <summary>
        /// The run unique identifier.
        /// </summary>
        [JsonProperty(PropertyName = "run_id")]
        public string RunId { get; set; }

        /// <summary>
        /// Map status.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public MapStatus Status { get; set; }

        /// <summary>
        /// Defines if the cleaning event has been launched from robot, schedule or app.
        /// </summary>
        [JsonProperty(PropertyName = "launched_from")]
        public MapLaunchedFrom LaunchedFrom { get; set; }

        /// <summary>
        /// Must be null if there are no errors. See Error Codes here below for a list of possible errors.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        /// <summary>
        /// Cleaning category.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public CleaningCategory Category { get; set; }

        /// <summary>
        /// Cleaning mode.
        /// </summary>
        [JsonProperty(PropertyName = "mode")]
        public CleaningMode Mode { get; set; }

        /// <summary>
        /// The cleaning frequency. 1 normal 2 double.
        /// </summary>
        [JsonProperty(PropertyName = "modifier")]
        public CleaningFrequency Modifier { get; set; }

        /// <summary>
        /// The ISO8601 formatted GMT date and time stating when the run was started.
        /// </summary>
        [JsonProperty(PropertyName = "start_at")]
        public DateTime StartAt { get; set; }

        /// <summary>
        /// The ISO8601 formatted GMT date and time stating when the run was ended.
        /// </summary>
        [JsonProperty(PropertyName = "end_at")]
        public DateTime EndAt { get; set; }

        /// <summary>
        /// The robot orientation when the run was finished or errored out.
        /// The value can be 0-360 indicating the degrees in clockwise rotation,
        /// where 0 is looking rightwards on the map.
        /// </summary>
        [JsonProperty(PropertyName = "end_orientation_relative_degrees")]
        public int EndOrientationRelativeDegrees { get; set; }

        /// <summary>
        /// The battery charge (in percentage) when the run was started.
        /// </summary>
        [JsonProperty(PropertyName = "run_charge_at_start")]
        public int RunChargeAtStart { get; set; }

        /// <summary>
        /// The battery charge (in percentage) when the run was finished or errored out.
        /// </summary>
        [JsonProperty(PropertyName = "run_charge_at_end")]
        public int RunChargeAtEnd { get; set; }

        /// <summary>
        /// The number of times the batteries were recharged during the run.
        /// </summary>
        [JsonProperty(PropertyName = "suspended_cleaning_charging_count")]
        public int SuspendedCleaningChargingCount { get; set; }

        /// <summary>
        /// Expresses the total time spent in suspended cleaning during the run (in seconds).
        /// </summary>
        [JsonProperty(PropertyName = "time_in_suspended_cleaning")]
        public int TimeInSuspendedCleaning { get; set; }

        /// <summary>
        /// Expresses the total time spent in error state during the run (in seconds).
        /// </summary>
        [JsonProperty(PropertyName = "time_in_error")]
        public int TimeInError { get; set; }

        /// <summary>
        /// Expresses the total time spent in paused state during the run (in seconds).
        /// </summary>
        [JsonProperty(PropertyName = "time_in_pause")]
        public int TimeInPause { get; set; }

        /// <summary>
        /// The area cleaned during the run (in square meters).
        /// </summary>
        [JsonProperty(PropertyName = "cleaned_area")]
        public decimal CleanedArea { get; set; }

        /// <summary>
        /// The number of bases seen.
        /// </summary>
        [JsonProperty(PropertyName = "base_count")]
        public int BaseCount { get; set; }

        /// <summary>
        /// Is the robot docket at the end of the run.
        /// </summary>
        [JsonProperty(PropertyName = "is_docked")]
        public bool IsDocked { get; set; }

        /// <summary>
        /// Defines if the robot was unable of properly relocalizing during the
        /// run (for instance, when picked up and moved by user).
        /// </summary>
        [JsonProperty(PropertyName = "delocalized")]
        public bool Delocalized { get; set; }
    }
}
