using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Forge.Security.Jwt.Shared.Storage
{

    /// <summary>Memory storage to persist tokens</summary>
    /// <typeparam name="TValue">Data type</typeparam>
    [Serializable]
    public class MemoryStorage<TValue> : IStorage<TValue>
    {

        private readonly ConcurrentDictionary<string, object> _dictionary = new ConcurrentDictionary<string, object>();

        /// <summary>Initializes a new instance of the <see cref="MemoryStorage{TValue}" /> class.</summary>
        public MemoryStorage()
        {
        }

        /// <summary>Clears items from the storage</summary>
        public async Task ClearAsync()
        {
            await Task.Run(() => _dictionary.Clear());
        }

        /// <summary>Determines whether the specified key exist or not.</summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified key exists; otherwise, <c>false</c>.</returns>
        public async Task<bool> ContainsKeyAsync(string key)
        {
            return await Task.FromResult(_dictionary.ContainsKey(key));
        }

        /// <summary>Gets stored data</summary>
        /// <returns>List of data</returns>
        public async Task<IEnumerable<TValue>> GetAsync()
        {
            return await Task.FromResult(_dictionary.Values.Select(i => (TValue)i).ToList<TValue>());
        }

        /// <summary>Gets the item by key</summary>
        /// <param name="key">The key.</param>
        /// <returns>Data or default</returns>
        public async Task<TValue> GetAsync(string key)
        {
            TValue result = default(TValue);
            object value = null;
            if (_dictionary.TryGetValue(key, out value))
            {
                result = (TValue)value;
            }
            return await Task.FromResult(result);
        }

        /// <summary>Removes an item from the storage</summary>
        /// <param name="key">The key.</param>
        /// <returns>True, if it was successful, otherwise, False.</returns>
        public async Task<bool> RemoveAsync(string key)
        {
            return await Task.FromResult(_dictionary.TryRemove(key, out _));
        }

        /// <summary>Add or update an item</summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        public async Task SetAsync(string key, TValue data)
        {
            await Task.Run(() => _dictionary.AddOrUpdate(key, data, (s, t) => data));
        }

    }
}
