using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColibImmo_WPF.API.JSON
{
    internal class ProjectCity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("zip_code")]
        public string? Zip_code { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("slug")]
        public string? Slug { get; set; }

        [JsonPropertyName("department_code")]
        public string? Department_code { get; set; }

        [JsonPropertyName("id_department")]
        public int? Id_department { get; set; }

      
    }
}
