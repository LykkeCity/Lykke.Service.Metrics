using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.Metrics.AutorestClient.Models;

namespace Lykke.Service.Metrics.Client
{
    public interface IKeyValueMetricLogsClient
    {
        Task<IReadOnlyCollection<string>> GetLogsNames();
        Task<string> GetLogHash(string name);
        Task<IReadOnlyCollection<LogEntry>> GetLog(string name);
        Task AddLogEntry(string logName, IEnumerable<KeyValuePair<string, string>> keyValues);
    }
}