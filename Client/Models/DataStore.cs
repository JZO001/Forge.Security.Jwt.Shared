namespace Forge.Security.Jwt.Shared.Client.Models
{

    public class DataStore
    {

        public ParsedTokenData TokenData { get; set; } = new ParsedTokenData();

        public string UserAgent { get; set; } = string.Empty;

    }

}
