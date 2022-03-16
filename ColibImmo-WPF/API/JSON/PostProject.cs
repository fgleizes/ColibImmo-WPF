using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColibImmo_WPF.API.JSON
{
    internal class PostProject
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("reference")]
        public string? Reference { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? UpdtedAt { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("area")]
        public int? area { get; set; }

        [JsonPropertyName("min_price")]
        public int? min_price { get; set; }

        [JsonPropertyName("max_price")]
        public int? max_price { get; set; }

        [JsonPropertyName("short_description")]
        public string? shortDescription { get; set; }

        [JsonPropertyName("id_Person")]
        public int? idPerson { get; set; }

        [JsonPropertyName("id_Type_project")]
        public int? idTypeProject { get; set; }

        [JsonPropertyName("id_Statut_project")]
        public object? idStatutproject { get; set; }

        [JsonPropertyName("id_Energy_index")]
        public object? idEnergyindex { get; set; }

        [JsonPropertyName("id_Address")]
        public object? idAddress { get; set; }

        [JsonPropertyName("id_PersonAgent")]
        public int? idPersonAgent { get; set; }

        [JsonPropertyName("option_project")]
        public object? optionProject { get; set; }

        [JsonPropertyName("room_project")]
        public object? roomProject { get; set; }

        [JsonPropertyName("type")]
        public int? Type { get; set; }

        [JsonPropertyName("rooms")]
        public string? Rooms { get; set; }

        [JsonPropertyName("options")]
        public string? Options { get; set; }
    }
}
