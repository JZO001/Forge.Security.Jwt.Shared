using Forge.Security.Jwt.Shared.Service.Models;
using System.Collections.Generic;

namespace Forge.Security.Jwt.Shared.Client.Services
{

    /// <summary>Represents the interface for the optional additional data</summary>
    public interface IAdditionalData
    {

        /// <summary>Gets or sets the secondary keys. Optionally include other metadata, such as user agent, ip address, device name, and so on</summary>
        /// <value>The secondary keys.</value>
        List<JwtKeyValuePair> SecondaryKeys { get; set; }

    }

}
