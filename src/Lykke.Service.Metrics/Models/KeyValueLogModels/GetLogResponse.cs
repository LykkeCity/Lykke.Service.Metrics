using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lykke.Service.Metrics.Models.KyeValueModels;

namespace Lykke.Service.Metrics.Models.KeyValueLogModels
{
    public class GetLogResponse
    {
        public class LogEntry
        {
            [Required]
            public DateTime Moment { get; set; }    
            public KeyValueModel[] KeyValues { get; set; }
        }

        public LogEntry[] Entries { get; set; }
    }
}