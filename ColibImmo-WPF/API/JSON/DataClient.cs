using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColibImmo_WPF.API.JSON
{
    internal class DataClient
    {
        [JsonPropertyName("lastname")]
        public string? lastname { get; set; }

        [JsonPropertyName("firstname")]
        public string? firstname { get; set; }

        [JsonPropertyName("mail")]
        public string mail { get; set; }

        [JsonPropertyName("phone")]
        public string? phone { get; set; }
    }
}
