using Forge.Security.Jwt.Shared.Client.Services;
using Forge.Security.Jwt.Shared.Service.Models;
using System.Collections.Generic;

namespace Forge.Security.Jwt.Shared.Client.Models
{

    /// <summary>Represents the default implementation for the optional additional data</summary>
    public class AdditionalData : IAdditionalData
    {

        /// <summary>Initializes a new instance of the <see cref="AdditionalData" /> class.</summary>
        public AdditionalData()
        {
        }

        /// <summary>Gets or sets the secondary keys. Optionally include other metadata, such as user agent, ip address, device name, and so on</summary>
        /// <value>The secondary keys.</value>
        public List<JwtKeyValuePair> SecondaryKeys { get; set; } = new List<JwtKeyValuePair>();

    }

}
