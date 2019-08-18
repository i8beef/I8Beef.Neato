using Newtonsoft.Json;

namespace I8Beef.Neato.BeeHive.Protocol
{
    /// <summary>
    /// Session Request.
    /// </summary>
    public class SessionResponse
    {
        /// <summary>
        /// Email.
        /// </summary>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
    }
}
