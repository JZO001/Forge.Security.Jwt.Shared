using Microsoft.Extensions.Options;
using System;
using System.Text.Json;

namespace Forge.Security.Jwt.Shared.Serialization
{

    /// <summary>Defines a generic serialization provider</summary>
    public class SystemTextJsonSerializer : ISerializationProvider
    {

        private readonly SystemTextJsonSerializerOptions _options;

        /// <summary>Initializes a new instance of the <see cref="SystemTextJsonSerializer" /> class.</summary>
        /// <param name="options">The options.</param>
        /// <exception cref="System.ArgumentNullException">options</exception>
        public SystemTextJsonSerializer(IOptions<SystemTextJsonSerializerOptions> options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (options.Value == null) throw new ArgumentNullException(nameof(options), "Options.Value cannot be null");
            _options = options.Value;
        }

        /// <summary>Initializes a new instance of the <see cref="SystemTextJsonSerializer" /> class.</summary>
        /// <param name="options">The options.</param>
        /// <exception cref="System.ArgumentNullException">options</exception>
        public SystemTextJsonSerializer(SystemTextJsonSerializerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            _options = options;
        }

        /// <summary>Deserializes the specified text.</summary>
        /// <typeparam name="TResult">Type of the output data</typeparam>
        /// <param name="text">The text.</param>
        /// <returns>The deserialized data</returns>
        public TResult Deserialize<TResult>(string text)
#if NETSTANDARD
            where TResult : class
#endif
        {
            return JsonSerializer.Deserialize<TResult>(text, _options.DeserializeOptions);
        }

        /// <summary>Serializes the specified object.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The object.</param>
        /// <returns>
        ///   The serialized content in string format
        /// </returns>
        public string Serialize<T>(T data)
        {
            return JsonSerializer.Serialize(data, _options.SerializeOptions);
        }

    }

}
