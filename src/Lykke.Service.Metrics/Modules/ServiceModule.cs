using Autofac;
using Common.Log;
using Lykke.Service.Metrics.Core;
using Lykke.Service.Metrics.Core.Services;
using Lykke.Service.Metrics.Services;

namespace Lykke.Service.Metrics.Modules
{
    public class ServiceModule : Module
    {
        private readonly MetricsSettings _settings;
        private readonly ILog _log;

        public ServiceModule(MetricsSettings settings, ILog log)
        {
            _settings = settings;
            _log = log;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_settings)
                .SingleInstance();

            builder.RegisterInstance(_log)
                .As<ILog>()
                .SingleInstance();

            builder.RegisterType<KeyValueStorage>().As<IKeyValueStorage>().SingleInstance();
            builder.RegisterType<KeyValueLogsStorage>().As<IKeyValueLogsStorage>().SingleInstance();
        }
    }
}
