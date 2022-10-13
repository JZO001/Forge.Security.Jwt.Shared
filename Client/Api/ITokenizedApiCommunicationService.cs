using System;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Security.Jwt.Shared.Client.Api
{

    /// <summary>Represents an API communication interface</summary>
    public interface ITokenizedApiCommunicationService
    {

        /// <summary>Occurs before the request sent out to prepare it manually</summary>
        event EventHandler<HttpRequestMessageEventArgs> OnPrepareRequest;

        /// <summary>Occurs after the response arrived. Gain full control over the content deserialization.</summary>
        event EventHandler<HttpResponseMessageEventArgs> OnPrepareResponse;

        /// <summary>Gets or sets the default encoding for sending.</summary>
        /// <value>The default encoding.</value>
        Encoding DefaultEncoding { get; set; }

        /// <summary>Gets or sets the access token.</summary>
        /// <value>The JWT bearer access token, which used for the Api calls. It will be added to the header.</value>
        string AccessToken { get; set; }

        /// <summary>Gets data</summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <returns>The result object</returns>
        Task<TResult> GetAsync<TResult>(string uri)
#if NETSTANDARD
            where TResult : class
#endif
            ;

        /// <summary>Posts data or creates a resource</summary>
        /// <typeparam name="TData">The type of the data.</typeparam>
        /// <typeparam name="TResult">The type of the result data.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="data">The data.</param>
        /// <returns>The result data</returns>
        Task<TResult> PostAsync<TData, TResult>(string uri, TData data)
#if NETSTANDARD
            where TData : class
            where TResult : class
#endif
            ;

        /// <summary>Puts data or update a resource</summary>
        /// <typeparam name="TData">The type of the data.</typeparam>
        /// <typeparam name="TResult">The type of the result data.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="data">The data.</param>
        /// <returns>The result data</returns>
        Task<TResult> PutAsync<TData, TResult>(string uri, TData data)
#if NETSTANDARD
            where TData : class
            where TResult : class
#endif
            ;

        /// <summary>Deletes a</summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <returns>The return data</returns>
        Task<TResult> DeleteAsync<TResult>(string uri)
#if NETSTANDARD
            where TResult : class
#endif
            ;

    }

}
