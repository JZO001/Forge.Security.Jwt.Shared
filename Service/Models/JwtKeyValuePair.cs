using System;
using System.Text.Json.Serialization;

namespace Forge.Security.Jwt.Shared.Service.Models
{

    /// <summary>Key and value pair for secondary key of a refresh token</summary>
    [Serializable]
    public class JwtKeyValuePair
    {

        /// <summary>Initializes a new instance of the <see cref="JwtKeyValuePair" /> class.</summary>
        public JwtKeyValuePair()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="JwtKeyValuePair" /> class.</summary>
        /// <param name="key">The key value (mandatory).</param>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">key</exception>
        public JwtKeyValuePair(string key, string value)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            Key = key;
            Value = value;
        }

        /// <summary>Gets or sets the key value, which is mandatory.</summary>
        /// <value>The key.</value>
        [JsonPropertyName("key")]
        public string Key { get; set; } = string.Empty;

        /// <summary>Gets or sets the value.
        /// It can be empty or null.</summary>
        /// <value>The value.</value>
        [JsonPropertyName("value")]
        public string Value { get; set; } = string.Empty;

    }

}
