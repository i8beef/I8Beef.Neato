using Newtonsoft.Json;

namespace I8Beef.Neato.Nucleo.Protocol.Services.ManualCleaning
{
    /// <summary>
    /// Robot manual cleaning info.
    /// </summary>
    public class RobotManualCleaningInfo
    {
        /// <summary>
        /// IP address.
        /// </summary>
        [JsonProperty(PropertyName = "ip_address")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Port.
        /// </summary>
        [JsonProperty(PropertyName = "port")]
        public string Port { get; set; }

        /// <summary>
        /// SSID.
        /// </summary>
        [JsonProperty(PropertyName = "ssid")]
        public string SSID { get; set; }
    }
}
