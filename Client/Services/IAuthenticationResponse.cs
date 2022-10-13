using System;

namespace Forge.Security.Jwt.Shared.Client.Services
{

    /// <summary>Represents the minimal service level of an authentication response message</summary>
    public interface IAuthenticationResponse
    {

        /// <summary>Gets or sets the access token.</summary>
        /// <value>The access token.</value>
        string AccessToken { get; set; }

        /// <summary>Gets or sets the refresh token.</summary>
        /// <value>The refresh token.</value>
        string RefreshToken { get; set; }

        /// <summary>Gets or sets the expiration time</summary>
        /// <value>The expiration time.</value>
        DateTime RefreshTokenExpireAt { get; set; }

    }

}
