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
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("id_Role")]
        public int? Id_Role { get; set; }

        [JsonPropertyName("lastname")]
        public string? Lastname { get; set; }

        [JsonPropertyName("firstname")]
        public string? Firstname { get; set; }

        [JsonPropertyName("mail")]
        public string? Mail { get; set; }

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        [JsonPropertyName("created_at")]
        public string? Created_at { get; set; }



        [JsonPropertyName("address")]
        public Address? Address { get; set; }
    }
}