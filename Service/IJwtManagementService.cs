using Forge.Security.Jwt.Shared.Service.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Forge.Security.Jwt.Shared.Service
{

    /// <summary>Jwt Management Service declaration</summary>
    public interface IJwtManagementService
    {

        /// <summary>Generates a new token.</summary>
        /// <param name="username">The username.
        /// Mandatory.</param>
        /// <param name="claims">The claims.</param>
        /// <param name="now">Indicates, when the token will be activated.</param>
        /// <param name="secondaryKeys">The secondary keys to identify a token.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Jwt access and refresh token</returns>
        Task<JwtTokenResult> GenerateTokensAsync(
            string username,
            Claim[] claims,
            DateTime now,
            IEnumerable<JwtKeyValuePair> secondaryKeys,
            CancellationToken cancellationToken = default);

        /// <summary>ValidateAsync the specified access and refresh tokens.</summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="now">The time when the refresh token will be active</param>
        /// <param name="secondaryKeys">The secondary keys.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True, if the tokens are valid, otherwise False.</returns>
        Task<JwtTokenValidationResultEnum> ValidateAsync(
            string refreshToken,
            string accessToken,
            DateTime now,
            IEnumerable<JwtKeyValuePair> secondaryKeys,
            CancellationToken cancellationToken = default);

        /// <summary>Generates new access and refresh tokens</summary>
        /// <param name="refreshToken">The refresh token.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="now">The time when the refresh token will be active</param>
        /// <param name="secondaryKeys">The secondary keys to identify the refresh token</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Jwt access and refresh token</returns>
        Task<JwtTokenResult> RefreshAsync(
            string refreshToken,
            string accessToken,
            DateTime now,
            IEnumerable<JwtKeyValuePair> secondaryKeys,
            CancellationToken cancellationToken = default);

        /// <summary>Removes the expired refresh tokens.</summary>
        /// <param name="now">The time before the tokens are expired</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True, if at least one token removed, otherwise False.</returns>
        ValueTask<bool> RemoveExpiredRefreshTokensAsync(DateTime now, CancellationToken cancellationToken = default);

        /// <summary>Removes the refresh token by user name and keys.</summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="secondaryKey">The secondary key.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True, if at least one token removed, otherwise False.</returns>
        ValueTask<bool> RemoveRefreshTokenByUserNameAndKeysAsync(string userName, IEnumerable<JwtKeyValuePair> secondaryKey, CancellationToken cancellationToken = default);

        /// <summary>Decodes the JWT token and get back the stored information</summary>
        /// <param name="token">The token.</param>
        /// <returns>ClaimsPrincipal and JwtSecurityToken</returns>
        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);

    }

}
