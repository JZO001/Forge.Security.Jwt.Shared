using System;
using System.Net;

namespace Forge.Security.Jwt.Shared.Client.Api
{

    /// <summary>Represent a unhandled failure of API call</summary>
    [Serializable]
    public class HttpRequestException : System.Net.Http.HttpRequestException
    {

        /// <summary>Initializes a new instance of the <see cref="HttpRequestException" /> class.</summary>
        /// <param name="code">The response Http status code.</param>
        /// <param name="responseContent">Content of the response in string.</param>
        public HttpRequestException(HttpStatusCode code, string responseContent) : this(code, responseContent, null, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="HttpRequestException" /> class.</summary>
        /// <param name="code">The response Http status code.</param>
        /// <param name="responseContent">Content of the response in string.</param>
        /// <param name="message">The optional exception message.</param>
        public HttpRequestException(HttpStatusCode code, string responseContent, string message) : this(code, responseContent, message, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="HttpRequestException" /> class.</summary>
        /// <param name="code">The response Http status code.</param>
        /// <param name="responseContent">Content of the response in string.</param>
        /// <param name="message">The optional exception message.</param>
        /// <param name="innerException">The optional inner exception.</param>
#if NETSTANDARD2_0 || NETCOREAPP3_1
        public HttpRequestException(HttpStatusCode code, string responseContent, string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = code;
            ResponseContent = responseContent;
        }
#else
        public HttpRequestException(HttpStatusCode code, string responseContent, string message, Exception innerException) : base(message, innerException, code)
        {
            ResponseContent = responseContent;
        }
#endif

        /// <summary>Gets the content of the response.</summary>
        /// <value>The content of the response.</value>
        public string ResponseContent { get; private set; }

#if NETSTANDARD2_0 || NETCOREAPP3_1
        /// <summary>
        /// Gets the HTTP status code to be returned with the exception.
        /// </summary>
        /// <value>
        /// An HTTP status code if the exception represents a non-successful result, otherwise <c>null</c>.
        /// </value>
        public HttpStatusCode StatusCode { get; }
#endif

    }

}
