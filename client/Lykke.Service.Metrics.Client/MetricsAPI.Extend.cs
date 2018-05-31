using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Lykke.Service.Metrics.AutorestClient
{
    public partial class MetricsAPI
    {
        /// <summary>
        /// Should be used to prevent memory leak in RetryPolicy
        /// </summary>
        public MetricsAPI(Uri baseUri, HttpClient client) : base(client)
        {
            Initialize();

            BaseUri = baseUri ?? throw new ArgumentNullException("baseUri");
        }
    }
}


