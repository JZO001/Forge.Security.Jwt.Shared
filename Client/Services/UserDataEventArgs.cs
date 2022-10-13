
/* Unmerged change from project 'Forge.Security.Jwt.Shared (net6.0)'
Before:
using System;
After:
using System;
using Forge;
using Forge.Security;
using Forge.Security.Jwt;
using Forge.Security.Jwt.Shared;
using Forge.Security.Jwt.Shared.Client;
using Forge.Security.Jwt.Shared.Client;
using Forge.Security.Jwt.Shared.Client.Models;
*/
using System;

namespace Forge.Security.Jwt.Shared.Client.Services
{

    /// <summary>Represents the user data in an event arguments</summary>
    [Serializable]
    public class UserDataEventArgs : EventArgs
    {

        /// <summary>Initializes a new instance of the <see cref="UserDataEventArgs" /> class.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <exception cref="ArgumentNullException">userId</exception>
        public UserDataEventArgs(string userId)
        {
            if (userId == null) throw new ArgumentNullException(nameof(userId));
            UserId = userId;
        }

        /// <summary>Gets the user identifier.</summary>
        /// <value>The user identifier.</value>
        public string UserId { get; private set; }

    }

}
