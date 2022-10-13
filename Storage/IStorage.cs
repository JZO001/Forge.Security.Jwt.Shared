using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forge.Security.Jwt.Shared.Storage
{

    /// <summary>Describes a storage with minimal required methods</summary>
    /// <typeparam name="TValue">Data type</typeparam>
    public interface IStorage<TValue>
    {

        /// <summary>Determines whether the specified key exist or not.</summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified key exists; otherwise, <c>false</c>.</returns>
        Task<bool> ContainsKeyAsync(string key);

        /// <summary>Gets stored data</summary>
        /// <returns>List of data</returns>
        Task<IEnumerable<TValue>> GetAsync();

        /// <summary>Gets the item by key</summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   Data or default
        /// </returns>
        Task<TValue> GetAsync(string key);

        /// <summary>Sets an item</summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        Task SetAsync(string key, TValue data);

        /// <summary>Removes an item from the storage</summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   True, if it was successful, otherwise, False.
        /// </returns>
        Task<bool> RemoveAsync(string key);

        /// <summary>Clears items from the storage</summary>
        Task ClearAsync();

    }

}
