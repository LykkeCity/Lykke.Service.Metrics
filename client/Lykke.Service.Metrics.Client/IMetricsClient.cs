namespace Lykke.Service.Metrics.Client
{
    public interface IMetricsClient
    {
        IKeyValueMetricsClient KeyValue { get; }
        IKeyValueMetricLogsClient KeyValueLogs { get; }
    }
}