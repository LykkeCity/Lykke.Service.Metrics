using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.Metrics.AutorestClient.Models;

namespace Lykke.Service.Metrics.Client
{
    public interface IKeyValueMetricLogsClient
    {
        Task<IReadOnlyCollection<string>> GetLogsNamesAsync();
        Task<string> GetLogHashAsync(string name);
        Task<IReadOnlyCollection<LogEntry>> GetLogAsync(string name);
        Task AddLogEntryAsync(string logName, IEnumerable<KeyValuePair<string, string>> keyValues);
    }
}