using System.Collections.Generic;

namespace Lykke.Service.Metrics.Core.Services
{
    public interface IKeyValueStorage
    {
        void Put(params KeyValuePair<string, string>[] data);
        KeyValuePair<string, string>[] GetAll();
    }
}