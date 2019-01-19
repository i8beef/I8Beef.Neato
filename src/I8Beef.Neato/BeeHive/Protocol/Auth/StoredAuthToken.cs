using System;

namespace I8Beef.Neato.BeeHive.Protocol.Auth
{
    /// <summary>
    /// Stored auth token.
    /// </summary>
    public class StoredAuthToken
    {
        /// <summary>
        /// Access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Refresh token.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Token expiration time.
        /// </summary>
        public DateTime TokenExpiration { get; set; }
    }
}
