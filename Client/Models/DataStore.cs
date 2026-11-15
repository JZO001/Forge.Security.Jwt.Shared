namespace Forge.Security.Jwt.Shared.Client.Models
{

    /// <summary>The client-side state the authentication services share (registered as a singleton).</summary>
    public class DataStore
    {

        /// <summary>The parsed data of the current token; an empty instance when there is none.</summary>
        public ParsedTokenData TokenData { get; set; } = new ParsedTokenData();

        /// <summary>The user agent of the browser, sent with the API requests; "." where no JS runtime is available.</summary>
        public string UserAgent { get; set; } = string.Empty;

    }

}
