using Forge.Security.Jwt.Shared.Client.Services;
using System;
using System.Text.Json.Serialization;

namespace Forge.Security.Jwt.Shared.Service.Models
{

    /// <summary>The result of the token generator</summary>
    [Serializable]
    public class JwtTokenResult : IAuthenticationResponse
    {

        /// <summary>Gets or sets the access token.</summary>
        /// <value>The access token.</value>
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        /// <summary>Gets or sets the refresh token.</summary>
        /// <value>The refresh token.</value>
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }

        /// <summary>Gets or sets the expiration time</summary>
        /// <value>The expiration time.</value>
        [JsonPropertyName("refreshTokenExpireAt")]
        public DateTime RefreshTokenExpireAt { get; set; } = DateTime.MinValue;

    }

}
