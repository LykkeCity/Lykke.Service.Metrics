using System;
using System.Net.Http;
using Common.Log;
using Lykke.Service.Metrics.AutorestClient;

namespace Lykke.Service.Metrics.Client
{
    public class MetricsClient : IMetricsClient, IDisposable
    {
        public IKeyValueMetricsClient KeyValue { get; }
        public IKeyValueMetricLogsClient KeyValueLogs { get; }

        private MetricsAPI _service;

        public MetricsClient(string serviceUrl)
        {
            _service = new MetricsAPI(new Uri(serviceUrl), new HttpClient());

            KeyValue = new KeyValueMetricsClient(_service);
            KeyValueLogs = new KeyValueMetricLogsClient(_service);
        }

        public void Dispose()
        {
            _service?.Dispose();
            _service = null;
        }
    }
}
