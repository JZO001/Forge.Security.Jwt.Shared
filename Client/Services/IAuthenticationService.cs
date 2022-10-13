using Forge.Security.Jwt.Shared.Client.Models;
using System;
using System.Threading.Tasks;

namespace Forge.Security.Jwt.Shared.Client.Services
{

    /// <summary>Provides basic functions to make a user authenticated</summary>
    public interface IAuthenticationService
    {

        /// <summary>Occurs when a user authentication state changed</summary>
        event EventHandler<UserDataEventArgs> OnUserAuthenticationStateChanged;

        /// <summary>Gets additional data, if something need to send at logout/refresh/validate</summary>
        /// <value>The logout data.</value>
        IAdditionalData AdditionalData { get; }

        /// <summary>Authenticates the user with the given credentials</summary>
        /// <typeparam name="TAuthCredentials">The type of the authentication credentials.</typeparam>
        /// <typeparam name="TAuthResult">The type of the authentication result.</typeparam>
        /// <param name="userCredentials">The user credentials.</param>
        /// <returns>Authentication result data</returns>
        Task<TAuthResult> AuthenticateUserAsync<TAuthCredentials, TAuthResult>(TAuthCredentials userCredentials)
            where TAuthCredentials : class, IAdditionalData
            where TAuthResult : class, IAuthenticationResponse, new();

        /// <summary>Logs out the current user.</summary>
        /// <returns>Task</returns>
        Task LogoutUserAsync();

        /// <summary>Gets the current user information.</summary>
        /// <returns>A data object which responded back by the provider/server/service</returns>
        Task<ParsedTokenData> GetCurrentUserInfoAsync();

        /// <summary>Validates the current token.</summary>
        /// <returns>True, if the token is valid, otherwise, False.</returns>
        Task<TokenValidationResponse> ValidateTokenAsync();

        /// <summary>Refreshes the current token and get a new one.</summary>
        /// <returns>The new token, or null, if it is not valid.</returns>
        Task<ParsedTokenData> RefreshTokenAsync();

    }

}
