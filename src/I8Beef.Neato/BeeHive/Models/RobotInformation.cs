using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace I8Beef.Neato.BeeHive.Models
{
    /// <summary>
    /// Robot information.
    /// </summary>
    public class RobotInformation
    {
        /// <summary>
        /// LinkedAt.
        /// </summary>
        [JsonProperty(PropertyName = "linked_at")]
        public DateTime LinkedAt { get; set; }

        /// <summary>
        /// Model.
        /// </summary>
        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Prefix.
        /// </summary>
        [JsonProperty(PropertyName = "prefix")]
        public string Prefix { get; set; }

        /// <summary>
        /// PurchasedAt.
        /// </summary>
        [JsonProperty(PropertyName = "purchased_at")]
        public DateTime PurchasedAt { get; set; }

        /// <summary>
        /// SecretKey.
        /// </summary>
        [JsonProperty(PropertyName = "secret_key")]
        public string SecretKey { get; set; }

        /// <summary>
        /// Serial.
        /// </summary>
        [JsonProperty(PropertyName = "serial")]
        public string Serial { get; set; }

        /// <summary>
        /// Traits.
        /// </summary>
        [JsonProperty(PropertyName = "traits")]
        public IList<string> Traits { get; set; }
    }
}
