using System.Text.Json;

namespace Forge.Security.Jwt.Shared.Serialization
{

    /// <summary>Default options for System.Text.Json serialization/deserialization</summary>
    public class SystemTextJsonSerializerOptions
    {

        /// <summary>The serialize options.</summary>
        /// <value>The serialize options.</value>
        public JsonSerializerOptions SerializeOptions { get; private set; } = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        /// <summary>The deserialize options.</summary>
        /// <value>The deserialize options.</value>
        public JsonSerializerOptions DeserializeOptions { get; private set; } = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

    }

}
