using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColibImmo_WPF.API.JSON
{
    internal class OptionProject
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("id")]
        public string? Name { get; set; }
    }
}
