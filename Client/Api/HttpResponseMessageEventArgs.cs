using System;
using System.Net.Http;

namespace Forge.Security.Jwt.Shared.Client.Api
{

    /// <summary>Represents the response message and optionally the deserialized content made by the event subscriber</summary>
    [Serializable]
    public class HttpResponseMessageEventArgs : EventArgs
    {

        /// <summary>Initializes a new instance of the <see cref="HttpResponseMessageEventArgs" /> class.</summary>
        /// <param name="responseMessage">The response message.</param>
        /// <param name="expectedResultType">The expected result type</param>
        /// <exception cref="ArgumentNullException">responseMessage</exception>
        public HttpResponseMessageEventArgs(HttpResponseMessage responseMessage, Type expectedResultType)
        {
            if (responseMessage == null) throw new ArgumentNullException(nameof(responseMessage));
            ResponseMessage = responseMessage;
            ExpectedResultType = expectedResultType;
        }

        /// <summary>Gets the response message.</summary>
        /// <value>The response message.</value>
        public HttpResponseMessage ResponseMessage { get; private set; }

        /// <summary>Gets the expected type of the result.</summary>
        /// <value>The expected type of the result.</value>
        public Type ExpectedResultType { get; private set; }

        /// <summary>Gets or sets the response data.</summary>
        /// <value>The response data which deserialized by the event subscriber code.</value>
        public object ResponseData { get; set; }

    }

}
