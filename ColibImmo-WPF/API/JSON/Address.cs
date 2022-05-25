using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColibImmo_WPF.API.JSON
{
    internal class Address
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("number")]
        public int? Number { get; set; }

        [JsonPropertyName("street")]
        public string? Street { get; set; }

        [JsonPropertyName("additional_address")]
        public string? AdditionalAddress { get; set; }

        [JsonPropertyName("building")]
        public string? Building { get; set; }

        [JsonPropertyName("floor")]
        public int? Floor { get; set; }

        [JsonPropertyName("residence")]
        public string? Residence { get; set; }

        [JsonPropertyName("staircase")]
        public string? Staircase { get; set; }

        [JsonPropertyName("City")]
        public City? City { get; set; }

    }
}
