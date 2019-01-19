using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo.Services.GeneralInfo
{
    /// <summary>
    /// GetGeneralInfo.
    /// </summary>
    public class GetGeneralInfo
    {
        /// <summary>
        /// Battery info.
        /// </summary>
        [JsonProperty(PropertyName = "battery")]
        public BatteryInformation Battery { get; set; }

        /// <summary>
        /// The software version, defined according to Semantic Versioning principles.
        /// The format is MAJOR.MINOR.PATCH-BUILDNUM, where BUILDNUM is a sequentially increasing number.
        /// </summary>
        [JsonProperty(PropertyName = "firmware")]
        public string Firmware { get; set; }

        /// <summary>
        /// The robot's interface language (if available).
        /// </summary>
        [JsonProperty(PropertyName = "model")]
        public string Language { get; set; }

        /// <summary>
        /// The robot model identifier. MUST be the same one as reported in meta/model.
        /// </summary>
        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        /// <summary>
        /// The Product number.
        /// </summary>
        [JsonProperty(PropertyName = "productNumber")]
        public string ProductNumber { get; set; }

        /// <summary>
        /// The robot serial number.
        /// </summary>
        [JsonProperty(PropertyName = "serial")]
        public string Serial { get; set; }
    }
}
