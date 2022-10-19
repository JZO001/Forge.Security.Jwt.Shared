using Forge.Security.Jwt.Shared.Client.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace Forge.Security.Jwt.Shared.Client.Services
{

    /// <summary>Interface for AuthenticationStateProvider</summary>
    public interface IJwtTokenAuthenticationStateProvider
    {

        /// <summary>
        /// An event that provides notification when the <see cref="AuthenticationState"/>
        /// has changed. For example, this event may be raised if a user logs in or out.
        /// </summary>
        event AuthenticationStateChangedHandler AuthenticationStateChanged;

        /// <summary>
        /// Asynchronously gets an <see cref="AuthenticationState"/> that describes the current user.
        /// </summary>
        /// <returns>A task that, when resolved, gives an <see cref="AuthenticationState"/> instance that describes the current user.</returns>
        Task<AuthenticationState> GetAuthenticationStateAsync();

        /// <summary>Authenticates the user with the gives login response</summary>
        /// <typeparam name="TAuthenticationResponse">The type of the login response.</typeparam>
        /// <param name="authenticationResponse">The login response.</param>
        /// <returns>Task</returns>
        Task AuthenticateUserAsync<TAuthenticationResponse>(TAuthenticationResponse authenticationResponse) where TAuthenticationResponse : IAuthenticationResponse, new();

        /// <summary>Authenticates the user with the given token.</summary>
        /// <param name="parsedTokenData">The parsed token data.</param>
        /// <returns>Task</returns>
        Task AuthenticateUserAsync(ParsedTokenData parsedTokenData);

        /// <summary>Marks the user as logged out</summary>
        /// <returns>Task</returns>
        Task LogoutUserAsync();

        /// <summary>Gets the parsed/extracted data asynchronously from the security token.</summary>
        /// <returns>ParsedTokenData</returns>
        Task<ParsedTokenData> GetParsedTokenDataAsync();

        /// <summary>Parses the response data and gives back ParsedTokenData object.</summary>
        /// <param name="loginResponse">The login response.</param>
        /// <returns>ParsedTokenData</returns>
        Task<ParsedTokenData> ParseTokenAsync(IAuthenticationResponse loginResponse);

    }

}
