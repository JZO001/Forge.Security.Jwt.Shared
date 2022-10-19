using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Forge.Security.Jwt.Shared.Client.Models
{

    /// <summary>Represents the parsed token data with the authentication result</summary>
    [Serializable]
    public sealed class ParsedTokenData : ICloneable
    {

        /// <summary>Gets the claims gathered from access token</summary>
        /// <value>The claims.</value>
        [JsonIgnore]
        [XmlIgnore]
        public List<Claim> Claims { get; private set; } = new List<Claim>();

        /// <summary>Gets or sets the access token.</summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }

        /// <summary>Gets or sets the expire time of the access token</summary>
        /// <value>Expire time</value>
        public DateTime AccessTokenExpireAt { get; set; } = DateTime.MinValue;

        /// <summary>Gets or sets the refresh token.</summary>
        /// <value>The refresh token.</value>
        public string RefreshToken { get; set; }

        /// <summary>Gets or sets the expire time of the refresh token</summary>
        /// <value>Expire time</value>
        public DateTime RefreshTokenExpireAt { get; set; } = DateTime.MinValue;

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            ParsedTokenData cloned = new ParsedTokenData();
            cloned.AccessToken = AccessToken;
            cloned.RefreshToken = RefreshToken;
            cloned.AccessTokenExpireAt = AccessTokenExpireAt;
            cloned.RefreshTokenExpireAt = RefreshTokenExpireAt;
            cloned.Claims.AddRange(Claims);
            return cloned;
        }

    }

}
