using Newtonsoft.Json;

namespace I8Beef.Neato.BeeHive.Protocol.Auth
{
    /// <summary>
    /// Refresh token request.
    /// </summary>
    public class RefreshTokenRequest
    {
        /// <summary>
        /// Grant type.
        /// </summary>
        [JsonProperty(PropertyName = "grant_type")]
        public string GrantType { get; set; } = "refresh_token";

        /// <summary>
        /// Refresh token.
        /// </summary>
        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }
    }
}
