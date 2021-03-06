// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Lykke.Service.Metrics.AutorestClient
{
    using Lykke.Service;
    using Lykke.Service.Metrics;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for MetricsAPI.
    /// </summary>
    public static partial class MetricsAPIExtensions
    {
            /// <summary>
            /// Checks service is alive
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IsAliveResponse IsAlive(this IMetricsAPI operations)
            {
                return operations.IsAliveAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Checks service is alive
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IsAliveResponse> IsAliveAsync(this IMetricsAPI operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.IsAliveWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<KeyValueModel> GetKeyValues(this IMetricsAPI operations)
            {
                return operations.GetKeyValuesAsync().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<KeyValueModel>> GetKeyValuesAsync(this IMetricsAPI operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetKeyValuesWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='data'>
            /// </param>
            public static void SaveKeyValues(this IMetricsAPI operations, IList<KeyValueModel> data = default(IList<KeyValueModel>))
            {
                operations.SaveKeyValuesAsync(data).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='data'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task SaveKeyValuesAsync(this IMetricsAPI operations, IList<KeyValueModel> data = default(IList<KeyValueModel>), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.SaveKeyValuesWithHttpMessagesAsync(data, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<string> GetLogNames(this IMetricsAPI operations)
            {
                return operations.GetLogNamesAsync().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<string>> GetLogNamesAsync(this IMetricsAPI operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetLogNamesWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='name'>
            /// </param>
            public static GetLogHashResponse GetLogHash(this IMetricsAPI operations, string name)
            {
                return operations.GetLogHashAsync(name).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='name'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<GetLogHashResponse> GetLogHashAsync(this IMetricsAPI operations, string name, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetLogHashWithHttpMessagesAsync(name, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='name'>
            /// </param>
            public static GetLogResponse GetLog(this IMetricsAPI operations, string name)
            {
                return operations.GetLogAsync(name).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='name'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<GetLogResponse> GetLogAsync(this IMetricsAPI operations, string name, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetLogWithHttpMessagesAsync(name, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='model'>
            /// </param>
            public static void AddLogEntry(this IMetricsAPI operations, AddLogEntryModel model = default(AddLogEntryModel))
            {
                operations.AddLogEntryAsync(model).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='model'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task AddLogEntryAsync(this IMetricsAPI operations, AddLogEntryModel model = default(AddLogEntryModel), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.AddLogEntryWithHttpMessagesAsync(model, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}
