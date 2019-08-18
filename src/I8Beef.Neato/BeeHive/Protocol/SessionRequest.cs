using Newtonsoft.Json;

namespace I8Beef.Neato.BeeHive.Protocol
{
    /// <summary>
    /// Session Request.
    /// </summary>
    public class SessionRequest
    {
        /// <summary>
        /// Email.
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Platform.
        /// </summary>
        [JsonProperty(PropertyName = "platform")]
        public string Platform { get; set; } = "ios";

        /// <summary>
        /// Token.
        /// </summary>
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}
