using Newtonsoft.Json;

namespace I8Beef.Neato.BeeHive.Models
{
    /// <summary>
    /// Persistent map information.
    /// </summary>
    public class PersistentMapInformation
    {
        /// <summary>
        /// Map id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Url.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Raw floor map url.
        /// </summary>
        [JsonProperty(PropertyName = "raw_floor_map_url")]
        public string RawFloorMapUrl { get; set; }

        /// <summary>
        /// The expiration time (in seconds) of the url.
        /// </summary>
        [JsonProperty(PropertyName = "url_valid_for_seconds")]
        public int UrlValidForSeconds { get; set; }
    }
}
