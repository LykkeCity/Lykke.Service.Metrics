using System.ComponentModel.DataAnnotations;

namespace Lykke.Service.Metrics.Models.KyeValueModels
{
    public class KeyValueModel
    {
        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }
    }
}