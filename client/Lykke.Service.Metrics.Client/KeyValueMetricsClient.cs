using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Lykke.Service.Metrics.AutorestClient;
using Lykke.Service.Metrics.AutorestClient.Models;

namespace Lykke.Service.Metrics.Client
{
    public class KeyValueMetricsClient : IKeyValueMetricsClient
    {
        private readonly IMetricsAPI _service;

        public KeyValueMetricsClient(IMetricsAPI service)
        {
            _service = service;
        }

        public async Task<IReadOnlyCollection<KeyValueModel>> GetAllAsync()
        {
            return new ReadOnlyCollection<KeyValueModel>(await _service.GetKeyValuesAsync());
        }

        public async Task SaveKeyValuesAsync(params KeyValueModel[] keyValues)
        {
            await _service.SaveKeyValuesAsync(keyValues);
        }
    }
}