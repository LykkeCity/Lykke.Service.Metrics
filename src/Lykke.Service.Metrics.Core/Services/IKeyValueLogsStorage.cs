using System;
using System.Collections.Generic;

namespace Lykke.Service.Metrics.Core.Services
{
    public interface IKeyValueLogsStorage
    {
        void Push(string collectionName, params KeyValuePair<string, string>[] events);
        IReadOnlyCollection<KeyValuePair<DateTime, KeyValuePair<string, string>[]>> GetLog(string collectionName);
        string GetHash(string collectionName);
        IEnumerable<string> GetLogNames();
    }
}