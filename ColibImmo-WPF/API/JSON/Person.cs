using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace ColibImmo_WPF.API.JSON
{
    internal class Person
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [JsonPropertyName("lastname")]
        public string? Lastname { get; set; }
        [JsonPropertyName("firstname")]
        public string? Firstname { get; set; }
        [JsonPropertyName("mail")]
        public string? Mail { get; set; }
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }
        [JsonPropertyName("password")]
        public string? Password { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime? Created_at { get; set; }
        [JsonPropertyName("updated_at")]
        public int? Updated_at { get; set; }
        [JsonPropertyName("id_Agency")]
        public int? IdAgency { get; set; }
        [JsonPropertyName("id_Address")]
        public int? IdAddress { get; set; }
        [JsonPropertyName("id_Role")]
        public int? IdRole { get; set; }
    }
}
