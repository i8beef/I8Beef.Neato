﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace I8Beef.Neato.BeeHive.Protocol
{
    /// <summary>
    /// Error reponse.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Message.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Errors.
        /// </summary>
        [JsonProperty(PropertyName = "errors")]
        public IDictionary<string, string> Errors { get; set; }
    }
}
