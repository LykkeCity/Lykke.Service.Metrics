using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Lykke.Service.Metrics.AutorestClient;
using Lykke.Service.Metrics.AutorestClient.Models;

namespace Lykke.Service.Metrics.Client
{
    public class KeyValueMetricLogsClient : IKeyValueMetricLogsClient
    {
        private readonly MetricsAPI _service;

        public KeyValueMetricLogsClient(MetricsAPI service)
        {
            _service = service;
        }

        public async Task<IReadOnlyCollection<string>> GetLogsNamesAsync()
        {
            return new ReadOnlyCollection<string>(await _service.GetLogNamesAsync());
        }

        public async Task<string> GetLogHashAsync(string name)
        {
            return (await _service.GetLogHashAsync(name)).Hash;
        }

        public async Task<IReadOnlyCollection<LogEntry>> GetLogAsync(string name)
        {
            return new ReadOnlyCollection<LogEntry>((await _service.GetLogAsync(name)).Entries);
        }

        public async Task AddLogEntryAsync(string logName, IEnumerable<KeyValuePair<string, string>> keyValues)
        {
            await _service.AddLogEntryAsync(new AddLogEntryModel
            {
                Id = logName,
                Data = keyValues
                    .Select(i => new KeyValueModel(i.Key, i.Value))
                    .ToArray()
            });
        }
    }
}