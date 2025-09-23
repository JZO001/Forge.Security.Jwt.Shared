using System;

namespace Forge.Security.Jwt.Shared.Client.Services
{

    /// <summary>Represents the token refresh service</summary>
    public interface IRefreshTokenService : IHostedService
    {

        /// <summary>Occurs when authentication required</summary>
        event EventHandler OnAuthenticationError;

    }

}
