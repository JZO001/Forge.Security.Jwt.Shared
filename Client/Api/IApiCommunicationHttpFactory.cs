using System.Net.Http;

namespace Forge.Security.Jwt.Shared.Client.Api
{

    /// <summary>Represents a HttpClient container which used for unique HttpClient configuration</summary>
    public interface IApiCommunicationHttpClientFactory
    {

        /// <summary>Gets the HTTP client.</summary>
        /// <value>The HTTP client.</value>
        HttpClient GetHttpClient();

    }

}
