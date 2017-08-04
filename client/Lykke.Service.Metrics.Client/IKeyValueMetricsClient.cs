using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.Metrics.AutorestClient.Models;

namespace Lykke.Service.Metrics.Client
{
    public interface IKeyValueMetricsClient
    {
        Task<IReadOnlyCollection<KeyValueModel>> GetAllAsync();
        Task SaveKeyValuesAsync(params KeyValueModel[] keyValues);
    }
}