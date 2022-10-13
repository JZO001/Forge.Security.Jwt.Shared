using Forge.Security.Jwt.Shared.Client.Services;
using System;

namespace Forge.Security.Jwt.Shared.Client.Models
{

    /// <summary>Login response data</summary>
    [Serializable]
    public class AuthenticationResponse : IAuthenticationResponse
    {

        /// <summary>Gets or sets the access token.</summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>Gets or sets the refresh token.</summary>
        /// <value>The refresh token.</value>
        public string RefreshToken { get; set; } = String.Empty;

        /// <summary>Gets or sets the expiration time</summary>
        /// <value>The expiration time.</value>
        public DateTime RefreshTokenExpireAt { get; set; } = DateTime.MinValue;

    }

}
