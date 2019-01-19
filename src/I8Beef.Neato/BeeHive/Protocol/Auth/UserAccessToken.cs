using Newtonsoft.Json;

namespace I8Beef.Neato.BeeHive.Protocol.Auth
{
    /// <summary>
    /// User access token.
    /// </summary>
    public class UserAccessToken
    {
        /// <summary>
        /// Access token.
        /// </summary>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Token type.
        /// </summary>
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; } = "bearer";

        /// <summary>
        /// Expires in.
        /// </summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Refresh token.
        /// </summary>
        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Scope.
        /// </summary>
        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }
    }
}
