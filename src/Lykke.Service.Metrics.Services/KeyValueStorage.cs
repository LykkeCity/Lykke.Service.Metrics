using System.Collections.Generic;
using System.Linq;
using Lykke.Service.Metrics.Core.Services;

namespace Lykke.Service.Metrics.Services
{
    public class KeyValueStorage : IKeyValueStorage
    {
        private readonly Dictionary<string, string> _cache = new Dictionary<string, string>();

        public void Put(params KeyValuePair<string, string>[] data)
        {
            lock (_cache)
            {
                foreach (var keyValuePair in data.Where(itm => !string.IsNullOrEmpty(itm.Key)))
                {
                    _cache[keyValuePair.Key] = keyValuePair.Value;
                }
            }
        }

        public KeyValuePair<string, string>[] GetAll()
        {
            lock (_cache)
            {
                return _cache.ToArray();
            }
        }

    }
}