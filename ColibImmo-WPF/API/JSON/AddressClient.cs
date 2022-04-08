using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColibImmo_WPF.API.JSON
{
    internal class AddressClient
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

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("zip_code")]
        public string? ZipCode { get; set; }

        [JsonPropertyName("department")]
        public string? Departement { get; set; }

        [JsonPropertyName("region")]
        public string? Region { get; set; }
    }
}
