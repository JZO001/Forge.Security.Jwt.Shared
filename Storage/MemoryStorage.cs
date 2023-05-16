using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using Forge.Security.Jwt.Shared.Serialization;

namespace Forge.Security.Jwt.Shared.Storage
{

    /// <summary>Memory storage to persist tokens</summary>
    /// <typeparam name="TValue">Data type</typeparam>
    [Serializable]
    public class MemoryStorage<TValue> : IStorage<TValue> where TValue : class, new()
    {

        private readonly ConcurrentDictionary<string, string> _dictionary = new ConcurrentDictionary<string, string>();
        private readonly ISerializationProvider _serializationProvider;

        /// <summary>Initializes a new instance of the <see cref="MemoryStorage{TValue}" /> class.</summary>
        public MemoryStorage(ISerializationProvider serializationProvider)
        {
            if (serializationProvider == null) throw new ArgumentNullException(nameof(serializationProvider));

            _serializationProvider = serializationProvider;
        }

        /// <summary>Clears items from the storage</summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task ClearAsync(CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _dictionary.Clear());
        }

        /// <summary>Determines whether the specified key exist or not.</summary>
        /// <param name="key">The key.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        ///   <c>true</c> if the specified key exists; otherwise, <c>false</c>.</returns>
        public async Task<bool> ContainsKeyAsync(string key, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(_dictionary.ContainsKey(key));
        }

        /// <summary>Gets stored data</summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>List of data</returns>
        public async Task<IEnumerable<TValue>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(_dictionary.Values.Select(json => Deserialize(json)).ToList<TValue>());
        }

        /// <summary>Gets the item by key</summary>
        /// <param name="key">The key.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Data or default</returns>
        public async Task<TValue> GetAsync(string key, CancellationToken cancellationToken = default)
        {
            TValue result = default(TValue);
            string json = string.Empty;
            if (_dictionary.TryGetValue(key, out json))
            {
                result = Deserialize(json);
            }
            return await Task.FromResult(result);
        }

        /// <summary>Removes an item from the storage</summary>
        /// <param name="key">The key.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True, if it was successful, otherwise, False.</returns>
        public async Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(_dictionary.TryRemove(key, out _));
        }

        /// <summary>Add or update an item</summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task SetAsync(string key, TValue data, CancellationToken cancellationToken = default)
        {
            string json = Serialize(data);
            await Task.Run(() => _dictionary.AddOrUpdate(key, json, (s, t) => json));
        }

        private string Serialize(TValue value)
        {
            return _serializationProvider.Serialize(value);
        }

        private TValue Deserialize(string json)
        {
            return _serializationProvider.Deserialize<TValue>(json);
        }

    }
}
