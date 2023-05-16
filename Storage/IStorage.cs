using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Forge.Security.Jwt.Shared.Storage
{

    /// <summary>Describes a storage with minimal required methods</summary>
    /// <typeparam name="TValue">Data type</typeparam>
    public interface IStorage<TValue> where TValue : class, new()
    {

        /// <summary>Determines whether the specified key exist or not.</summary>
        /// <param name="key">The key.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <c>true</c> if the specified key exists; otherwise, <c>false</c>.</returns>
        Task<bool> ContainsKeyAsync(string key, CancellationToken cancellationToken = default);

        /// <summary>Gets stored data</summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>List of data</returns>
        Task<IEnumerable<TValue>> GetAsync(CancellationToken cancellationToken = default);

        /// <summary>Gets the item by key</summary>
        /// <param name="key">The key.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   Data or default. The data must be always a new instance based the original object.
        /// </returns>
        Task<TValue> GetAsync(string key, CancellationToken cancellationToken = default);

        /// <summary>Sets an item</summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task SetAsync(string key, TValue data, CancellationToken cancellationToken = default);

        /// <summary>Removes an item from the storage</summary>
        /// <param name="key">The key.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   True, if it was successful, otherwise, False.
        /// </returns>
        Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default);

        /// <summary>Clears items from the storage</summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task ClearAsync(CancellationToken cancellationToken = default);

    }

}
