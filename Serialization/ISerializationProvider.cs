namespace Forge.Security.Jwt.Shared.Serialization
{

    /// <summary>Defines a generic serialization provider</summary>
    public interface ISerializationProvider
    {

        /// <summary>Serializes the specified object.</summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///   The serialized content in string format
        /// </returns>
        string Serialize<TData>(TData obj);

        /// <summary>Deserializes the specified text.</summary>
        /// <typeparam name="TResult">Type of the output data</typeparam>
        /// <param name="text">The text.</param>
        /// <returns>The deserialized data</returns>
        TResult Deserialize<TResult>(string text)
#if NETSTANDARD
            where TResult : class
#endif
            ;

    }

}
