using System;
using System.Collections.Generic;
using System.Linq;
using Lykke.Service.Metrics.Core.Services;

namespace Lykke.Service.Metrics.Services
{
    public class KeyValueLogsStorage : IKeyValueLogsStorage
    {
        private const int MaxRecords = 50;

        private readonly Dictionary<string, List<KeyValuePair<DateTime, KeyValuePair<string, string>[]>>> _cache;

        private readonly Dictionary<string, string> _dataHashes;

        private static readonly KeyValuePair<DateTime, KeyValuePair<string, string>[]>[] NullData;

        static KeyValueLogsStorage()
        {
            NullData = new KeyValuePair<DateTime, KeyValuePair<string, string>[]>[0];
        }

        public KeyValueLogsStorage()
        {
            _cache = new Dictionary<string, List<KeyValuePair<DateTime, KeyValuePair<string, string>[]>>>();
            _dataHashes = new Dictionary<string, string>();
        }
        
        public void Push(string collectionName, params KeyValuePair<string, string>[] events)
        {

            if (string.IsNullOrEmpty(collectionName))
            {
                return;
            }

            lock (_cache)
            {
                if (!_cache.ContainsKey(collectionName))
                {
                    _cache.Add(collectionName, new List<KeyValuePair<DateTime, KeyValuePair<string, string>[]>>());
                }

                var collection = _cache[collectionName];

                // TODO: Should use ToDictionary, to exclude duplicate keys, but using array for now, to preserve contract
                var filterEmptyKeys = events.Where(itm => !string.IsNullOrEmpty(itm.Key)).ToArray();

                collection.Insert(0, new KeyValuePair<DateTime, KeyValuePair<string, string>[]>(DateTime.UtcNow, filterEmptyKeys));

                while (collection.Count > MaxRecords)
                {
                    collection.RemoveAt(collection.Count - 1);
                }

                _dataHashes[collectionName] = Guid.NewGuid().ToString("N");
            }

        }

        public IReadOnlyCollection<KeyValuePair<DateTime, KeyValuePair<string, string>[]>> GetLog(string collectionName)
        {
            lock (_cache)
            {
                if (!_cache.ContainsKey(collectionName))
                    return NullData;

                var result = new List<KeyValuePair<DateTime, KeyValuePair<string, string>[]>>();

                foreach (var keyValuePair in _cache[collectionName])
                {
                    result.Add(new KeyValuePair<DateTime, KeyValuePair<string, string>[]>(keyValuePair.Key, keyValuePair.Value));
                }

                return result;
            }
        }


        public string GetHash(string collectionName)
        {
            lock (_cache)
            {
                return _dataHashes.ContainsKey(collectionName) ? _dataHashes[collectionName] : Guid.NewGuid().ToString("N");
            }
        }


        public IEnumerable<string> GetLogNames()
        {
            lock (_cache)
            {
                return _cache.Keys.ToArray();
            }
        }
    }
}