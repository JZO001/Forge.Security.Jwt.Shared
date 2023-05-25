using Forge.Security.Jwt.Shared.Client.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Forge.Security.Jwt.Shared.Client.Services
{

    /// <summary>Provides basic functions to make a user authenticated</summary>
    public interface IAuthenticationService
    {

        /// <summary>Occurs when a user authentication state changed</summary>
        event EventHandler<UserDataEventArgs> OnUserAuthenticationStateChanged;

        /// <summary>Authenticates the user with the given credentials</summary>
        /// <typeparam name="TAuthCredentials">The type of the authentication credentials.</typeparam>
        /// <typeparam name="TAuthResult">The type of the authentication result.</typeparam>
        /// <param name="userCredentials">The user credentials.</param>
        /// <returns>Authentication result data</returns>
        Task<TAuthResult> AuthenticateUserAsync<TAuthCredentials, TAuthResult>(TAuthCredentials userCredentials)
            where TAuthCredentials : class, IAdditionalData
            where TAuthResult : class, IAuthenticationResponse, new();

        /// <summary>Authenticates the user with the given credentials</summary>
        /// <typeparam name="TAuthCredentials">The type of the authentication credentials.</typeparam>
        /// <typeparam name="TAuthResult">The type of the authentication result.</typeparam>
        /// <param name="userCredentials">The user credentials.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Authentication result data</returns>
        Task<TAuthResult> AuthenticateUserAsync<TAuthCredentials, TAuthResult>(TAuthCredentials userCredentials, CancellationToken cancellationToken)
            where TAuthCredentials : class, IAdditionalData
            where TAuthResult : class, IAuthenticationResponse, new();

        /// <summary>Logs out the current user.</summary>
        /// <returns>True, if the logout was successful, otherwise, False</returns>
        Task<bool> LogoutUserAsync();

        /// <summary>Logs out the current user.</summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True, if the logout was successful, otherwise, False</returns>
        Task<bool> LogoutUserAsync(CancellationToken cancellationToken);

        /// <summary>Gets the current user information.</summary>
        /// <returns>A data object which responded back by the provider/server/service</returns>
        Task<ParsedTokenData> GetCurrentUserInfoAsync();

        /// <summary>Validates the current token.</summary>
        /// <returns>True, if the token is valid, otherwise, False.</returns>
        Task<bool> ValidateTokenAsync();

        /// <summary>Validates the current token.</summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True, if the token is valid, otherwise, False.</returns>
        Task<bool> ValidateTokenAsync(CancellationToken cancellationToken);

        /// <summary>Refreshes the current token and get a new one.</summary>
        /// <returns>The new token, or null, if it is not valid.</returns>
        Task<ParsedTokenData> RefreshTokenAsync();

        /// <summary>Refreshes the current token and get a new one.</summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The new token, or null, if it is not valid.</returns>
        Task<ParsedTokenData> RefreshTokenAsync(CancellationToken cancellationToken);

    }

}
