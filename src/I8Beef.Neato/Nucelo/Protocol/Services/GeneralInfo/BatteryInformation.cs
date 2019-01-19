using System;
using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo.Protocol.Services.GeneralInfo
{
    /// <summary>
    /// BatteryInformation response.
    /// </summary>
    public class BatteryInformation
    {
        /// <summary>
        /// The battery authorization status.
        /// </summary>
        [JsonProperty(PropertyName = "authorizationStatus")]
        public AuthorizationStatus AuthorizationStatus { get; set; }

        /// <summary>
        /// Expresses the battery bar level (1-4).
        /// </summary>
        [JsonProperty(PropertyName = "level")]
        public int Level { get; set; }

        /// <summary>
        /// The ISO8601 formatted date (YYYY-MM-DD) stating when the battery was manufactured.
        /// </summary>
        [JsonProperty(PropertyName = "manufacturingDate")]
        public DateTime ManufacturingDate { get; set; }

        /// <summary>
        /// How many minutes is the battery able to run. null if the robot is currently computing it.
        /// </summary>
        [JsonProperty(PropertyName = "timeToEmpty")]
        public int TimeToEmpty { get; set; }

        /// <summary>
        /// How many minutes are needed to fully recharge the battery at its current level. null if the 
        /// </summary>
        [JsonProperty(PropertyName = "timeToFullCharge")]
        public int TimeToFullCharge { get; set; }

        /// <summary>
        /// The total number of battery charges since it was manufactured.
        /// </summary>
        [JsonProperty(PropertyName = "totalCharges")]
        public int TotalCharges { get; set; }

        /// <summary>
        /// The vendor name.
        /// </summary>
        [JsonProperty(PropertyName = "vendor")]
        public string Vendor { get; set; }
    }
}
