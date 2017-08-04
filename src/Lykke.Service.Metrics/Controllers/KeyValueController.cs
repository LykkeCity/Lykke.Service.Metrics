using System.Collections.Generic;
using System.Linq;
using System.Net;
using Lykke.Service.Metrics.Core.Services;
using Lykke.Service.Metrics.Models;
using Lykke.Service.Metrics.Models.KyeValueModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;

namespace Lykke.Service.Metrics.Controllers
{
    [Route("api/keyValues")]
    public class KeyValueController : Controller
    {
        private readonly IKeyValueStorage _keyValueStorage;

        public KeyValueController(IKeyValueStorage keyValueStorage)
        {
            _keyValueStorage = keyValueStorage;
        }

        [HttpGet]
        [SwaggerOperation("GetKeyValues")]
        [ProducesResponseType(typeof(IEnumerable<KeyValueModel>), (int)HttpStatusCode.OK)]
        public IActionResult GetKeys()
        {
            var data = _keyValueStorage.GetAll().Select(itm => new KeyValueModel { Key = itm.Key, Value = itm.Value });

            return Ok(data);
        }

        // TODO: Replace with PUT
        [HttpPost]
        [SwaggerOperation("SaveKeyValues")]
        public IActionResult SaveKeyValues([FromBody] KeyValueModel[] data)
        {
            var model = data.Select(itm => new KeyValuePair<string, string>(itm.Key, itm.Value)).ToArray();

            _keyValueStorage.Put(model);

            return Ok(new { result = "OK" });
        }
    }
}