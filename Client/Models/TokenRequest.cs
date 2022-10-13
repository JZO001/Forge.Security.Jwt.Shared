using Forge.Security.Jwt.Shared.Client.Services;
using Forge.Security.Jwt.Shared.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Forge.Security.Jwt.Shared.Client.Models
{

    /// <summary>Request object for refresh token operations</summary>
    [Serializable]
    public class TokenRequest : IAdditionalData
    {

        /// <summary>Gets or sets the token string.</summary>
        /// <value>The token string.</value>
        [Required]
        [JsonPropertyName("refreshTokenString")]
        public string RefreshTokenString { get; set; } = string.Empty;

        /// <summary>Gets or sets the secondary keys.
        /// Optionally include other metadata, such as user agent, ip address, device name, and so on</summary>
        /// <value>The secondary keys.</value>
        [JsonPropertyName("secondaryKeys")]
        public List<JwtKeyValuePair> SecondaryKeys { get; set; } = new List<JwtKeyValuePair>();

    }

}
