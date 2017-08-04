using System;
using Autofac;

namespace Lykke.Service.Metrics.Client
{
    public static class AutofacExtension
    {
        public static void RegisterMetricsClient(this ContainerBuilder builder, string serviceUrl)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (serviceUrl == null) throw new ArgumentNullException(nameof(serviceUrl));
            if (string.IsNullOrWhiteSpace(serviceUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(serviceUrl));

            builder.RegisterInstance(new MetricsClient(serviceUrl)).As<IMetricsClient>().SingleInstance();
        }
    }
}
