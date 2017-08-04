using System.ComponentModel.DataAnnotations;
using Lykke.Service.Metrics.Models.KyeValueModels;

namespace Lykke.Service.Metrics.Models.KeyValueLogModels
{
    public class AddLogEntryModel
    {
        /// <summary>
        /// Log name
        /// </summary>
        [Required]
        public string Id { get; set; }

        [Required]
        public KeyValueModel[] Data { get; set; }
    }
}