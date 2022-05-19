using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace ColibImmo_WPF.API.JSON
{
    internal class City
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("id_Department")]
        public int? IdDepartment { get; set; }

        [JsonPropertyName("zip_code")]
        public string? ZipCode { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("insee_code")]
        public string? InseeCode { get; set; }

        [JsonPropertyName("slug")]
        public string? Slug { get; set; }

        [JsonPropertyName("gps_lat")]
        public double? GpsLat { get; set; }

        [JsonPropertyName("gps_lng")]
        public double? GpsLng { get; set; }

        [JsonPropertyName("department_code")]
        public string? DepartmentCode { get; set; }


        [JsonPropertyName("Departement")]
        public Departement? Departement { get; set; }


    }
}
