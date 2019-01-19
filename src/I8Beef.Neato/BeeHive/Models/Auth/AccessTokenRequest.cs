using Newtonsoft.Json;

namespace I8Beef.Neato.BeeHive.Models.Auth
{
    /// <summary>
    /// Access token request.
    /// </summary>
    public class AccessTokenRequest
    {
        /// <summary>
        /// Grant type.
        /// </summary>
        [JsonProperty(PropertyName = "grant_type")]
        public string GrantType { get; set; }

        /// <summary>
        /// Client id.
        /// </summary>
        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Client secret.
        /// </summary>
        [JsonProperty(PropertyName = "client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Redirect uri.
        /// </summary>
        [JsonProperty(PropertyName = "redirect_uri")]
        public string RedirectUri { get; set; }

        /// <summary>
        /// Code.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
    }
}
