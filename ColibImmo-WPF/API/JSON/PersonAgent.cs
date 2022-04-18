using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColibImmo_WPF.API.JSON
{
    internal class PersonAgent
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [JsonPropertyName("lastname")]
        public string? Lastname { get; set; }
        [JsonPropertyName("firstname")]
        public string? Firstname { get; set; }
        [JsonPropertyName("mail")]
        public string? Mail { get; set; }
        

    }
}
