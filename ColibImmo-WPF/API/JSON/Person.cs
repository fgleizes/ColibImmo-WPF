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
        [JsonPropertyName("id_Role")]
        public int? idRole { get; set; }
        //[JsonPropertyName("address")]
        //public Address? Address { get; set; }
    }
}
