using Forge.Security.Jwt.Shared.Service.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Forge.Security.Jwt.Shared.Client.Models
{

    /// <summary>Represents the settings of the client side authentication framework</summary>
    public class JwtClientAuthenticationCoreOptions
    {

        /// <summary>Gets or sets the base address of the HttpClient.</summary>
        /// <value>The base address.</value>
        public string BaseAddress { get; set; } = string.Empty;

        /// <summary>Gets or sets the authentication URI.</summary>
        /// <value>The authentication URI.</value>
        public string AuthenticationUri { get; set; } = "api/auth/login";

        /// <summary>Gets or sets the logout URI.</summary>
        /// <value>The logout URI.</value>
        public string LogoutUri { get; set; } = "api/auth/logout";

        /// <summary>Gets or sets the validation URI.</summary>
        /// <value>The logout URI.</value>
        public string ValidateTokenUri { get; set; } = "api/auth/validate-token";

        /// <summary>Gets or sets the refresh URI.</summary>
        /// <value>The logout URI.</value>
        public string RefreshUri { get; set; } = "api/auth/refresh-token";

        /// <summary>Gets or sets the HTTP message handler for the HttpClient.</summary>
        /// <value>The HTTP message handler.</value>
        public Func<HttpMessageHandler> HttpMessageHandlerFactory { get; set; }

        /// <summary>Gets or sets the additional data.</summary>
        /// <value>The additional data.</value>
        public List<JwtKeyValuePair> SecondaryKeys { get; set; } = new List<JwtKeyValuePair>();

        /// <summary>Gets or sets the value in milliseconds, when the service refresh the token before it expired</summary>
        /// <value>The refresh token before expiration in milliseconds.</value>
        public int RefreshTokenBeforeExpirationInMilliseconds { get; set; } = 15000;

    }

}
