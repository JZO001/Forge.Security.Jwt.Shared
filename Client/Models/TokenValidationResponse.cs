using System;
using System.Text.Json.Serialization;

namespace Forge.Security.Jwt.Shared.Client.Models
{

    /// <summary>Represents the result of the token validation</summary>
    [Serializable]
    public class TokenValidationResponse
    {

        /// <summary>Represents the validation result</summary>
        /// <value>Returns True, if the token is valid, otherwise False</value>
        [JsonPropertyName("isValid")]
        public bool IsValid { get; set; }

    }

}
