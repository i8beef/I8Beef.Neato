using Newtonsoft.Json;

namespace I8Beef.Neato.Nucelo.Services.Response
{
    /// <summary>
    /// Meta information.
    /// </summary>
    public class MetaInformation
    {
        /// <summary>
        /// Model name.
        /// </summary>
        [JsonProperty(PropertyName = "modelName")]
        public string ModelName { get; set; }

        /// <summary>
        /// Firmware.
        /// </summary>
        [JsonProperty(PropertyName = "firmware")]
        public string Firmware { get; set; }
    }
}
