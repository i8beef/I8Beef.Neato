using System.Runtime.Serialization;

namespace I8Beef.Neato.Nucelo.Services.Response
{
    /// <summary>
    /// Result type.
    /// </summary>
    public enum ResultType
    {

        /// <summary>
        /// OK.
        /// </summary>
        [EnumMember(Value = "ok")]
        Ok,

        /// <summary>
        /// Invalid JSON.
        /// </summary>
        [EnumMember(Value = "invalid_json")]
        InvalidJson,

        /// <summary>
        /// Bad request.
        /// </summary>
        [EnumMember(Value = "bad_request")]
        BadRequest,

        /// <summary>
        /// Command not found.
        /// </summary>
        [EnumMember(Value = "command_not_found")]
        CommandNotFound,

        /// <summary>
        /// Command rejected.
        /// </summary>
        [EnumMember(Value = "command_rejected")]
        CommandRejected,

        /// <summary>
        /// KO.
        /// </summary>
        [EnumMember(Value = "ko")]
        Ko
    }
}
