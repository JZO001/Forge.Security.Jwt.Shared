using System;

namespace Forge.Security.Jwt.Shared.Service.Models
{

    /// <summary>Represents the refresh token validation result</summary>
    [Serializable]
    public enum JwtTokenValidationResultEnum
    {
        /// <summary>Valid</summary>
        Valid = 0,
        /// <summary>Jwt access token decoding error</summary>
        JwtTokenDecodingError,
        /// <summary>The signature algorithm mismatch</summary>
        SignatureAlgorithmMismatch,
        /// <summary>The refresh token not found</summary>
        RefreshTokenNotFound,
        /// <summary>The username mismatch</summary>
        UsernameMismatch,
        /// <summary>The refresh token expired</summary>
        RefreshTokenExpired,
        /// <summary>The secondary keys mismatch</summary>
        SecondaryKeysMismatch
    }

}
