using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColibImmo_WPF.API.JSON
{
    internal class ProjectAddress
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("number")]
        public int? Number { get; set; }

        [JsonPropertyName("street")]
        public string? Street { get; set; }

        [JsonPropertyName("additional_address")]
        public string? Additional_address { get; set; }

        [JsonPropertyName("building")]
        public string? Building { get; set; }

        [JsonPropertyName("floor")]
        public int? Floor { get; set; }

        [JsonPropertyName("residence")]
        public string? Residence { get; set; }

        [JsonPropertyName("staircase")]
        public string? Staircase { get; set; }

        [JsonPropertyName("city")]
        public ProjectCity? City { get; set; }

        [JsonPropertyName("department")]
        public Object? Department { get; set; }

        [JsonPropertyName("region")]
        public Object? Degion { get; set; }



    }
}
