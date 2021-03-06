using System.Text.Json.Serialization;

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
        public AddressClient? AddressClient { get; set; }
    }
}