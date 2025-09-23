using System;
using System.Runtime.Serialization;

namespace Forge.Security.Jwt.Shared
{

    /// <summary>Authentication Exception</summary>
    [Serializable]
    public class AuthenticationException : Exception
    {

        /// <summary>Initializes a new instance of the <see cref="AuthenticationException" /> class.</summary>
        public AuthenticationException()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="AuthenticationException" /> class.</summary>
        /// <param name="message">The message that describes the error.</param>
        public AuthenticationException(string message) : base(message)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="AuthenticationException" /> class.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public AuthenticationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="AuthenticationException" /> class.</summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo">SerializationInfo</see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext">StreamingContext</see> that contains contextual information about the source or destination.</param>
        protected AuthenticationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }

}
