using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace Forge.Security.Jwt.Shared
{

    /// <summary>Help parse an access token</summary>
    public static class JwtParserHelper
    {

        /// <summary>Parses JWT access token to get the claims.</summary>
        /// <param name="jwtAccessToken">The JWT access token.</param>
        /// <returns>List of extracted Claim(s)</returns>
        public static List<Claim> ParseClaimsFromJwt(string jwtAccessToken)
        {
            return ParseClaimsFromJwt(jwtAccessToken, out _);
        }

        /// <summary>Parses JWT access token to get the claims.</summary>
        /// <param name="jwtAccessToken">The JWT access token.</param>
        /// <param name="isSuccess">Indicates whether parsing was successful.</param>
        /// <returns>List of extracted Claim(s)</returns>
        public static List<Claim> ParseClaimsFromJwt(string jwtAccessToken, out bool isSuccess)
        {
            isSuccess = false;

            List<Claim> claims = new List<Claim>();

            if (!string.IsNullOrWhiteSpace(jwtAccessToken))
            {
                try
                {
                    string payload = jwtAccessToken.Split('.')[1];
                    byte[] jsonBytes = ParseBase64WithoutPadding(payload);
                    Dictionary<string, object> keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

                    object roles = null;
                    if (keyValuePairs != null) keyValuePairs.TryGetValue(ClaimTypes.Role, out roles);

                    if (roles != null)
                    {
                        if (roles.ToString().Trim().StartsWith("[", StringComparison.OrdinalIgnoreCase))
                        {
                            string[] parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                            if (parsedRoles != null)
                            {
                                foreach (string parsedRole in parsedRoles)
                                {
                                    claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                                }
                            }
                        }
                        else
                        {
                            claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                        }

                        keyValuePairs.Remove(ClaimTypes.Role);
                    }

                    claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
                    
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                    // ignored
                    Debug.WriteLine("ParseClaimsFromJwt failed: " + ex.ToString());
                    claims.Clear();
                }
            }

            return claims;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

    }

}
