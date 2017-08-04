using System.Collections.Generic;
using System.Linq;
using System.Net;
using Lykke.Service.Metrics.Core.Services;
using Lykke.Service.Metrics.Models.KeyValueLogModels;
using Lykke.Service.Metrics.Models.KyeValueModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;

namespace Lykke.Service.Metrics.Controllers
{
    [Route("api/keyValueLogs")]
    public class KeyValueLogsController : Controller
    {
        private readonly IKeyValueLogsStorage _keyValueLogsStorage;

        public KeyValueLogsController(IKeyValueLogsStorage keyValueLogsStorage)
        {
            _keyValueLogsStorage = keyValueLogsStorage;
        }

        [HttpGet("names")]
        [SwaggerOperation("GetLogNames")]
        [ProducesResponseType(typeof(IEnumerable<string>), (int)HttpStatusCode.OK)]
        public IActionResult GetLogNames()
        {
            var data = _keyValueLogsStorage.GetLogNames();

            return Json(data);
        }

        [HttpGet("{name}/hash")]
        [SwaggerOperation("GetLogHash")]
        [ProducesResponseType(typeof(GetLogHashResponse), (int)HttpStatusCode.OK)]
        public IActionResult GetLogHash(string name)
        {
            var hash = _keyValueLogsStorage.GetHash(name);

            return Ok(new GetLogHashResponse
            {
                Hash = hash
            });
        }

        [HttpGet("{name}")]
        [SwaggerOperation("GetLog")]
        [ProducesResponseType(typeof(GetLogResponse), (int)HttpStatusCode.OK)]
        public IActionResult GetCollection(string name)
        {
            var entries = _keyValueLogsStorage.GetLog(name);

            return Ok(new GetLogResponse
            {
                Entries = entries
                    .Select(e => new GetLogResponse.LogEntry
                    {
                        Moment = e.Key,
                        KeyValues = e.Value
                            .Select(i => new KeyValueModel
                            {
                                Key = i.Key,
                                Value = i.Value
                            })
                            .ToArray()
                    })
                    .ToArray()
            });
        }
        
        // TODO: Log name should be passed in URL 
        [HttpPost("")]
        [SwaggerOperation("AddLogEntry")]
        public IActionResult SaveLine([FromBody] AddLogEntryModel model)
        {
            var rows = model.Data
                .Select(itm => new KeyValuePair<string, string>(itm.Key, itm.Value))
                .ToArray();

            _keyValueLogsStorage.Push(model.Id, rows);

            return Ok(new { result = "OK" });
        }
    }
}