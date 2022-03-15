using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColibImmo_WPF.API.JSON
{
    internal class Project
    {
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
        public int? Area { get; set; }
        
        [JsonPropertyName("min_price")]
        public int? Min_price { get; set; }

        [JsonPropertyName("max_price")]
        public int? Max_price { get; set; }

        [JsonPropertyName("short_description")]
        public string? shortDescription { get; set; }
        
        [JsonPropertyName("id_Person")]
        public object? IdPerson { get; set; }

        [JsonPropertyName("id_Type_project")]
        public object? IdTypeProject { get; set; }

        [JsonPropertyName("id_Statut_project")]
        public object? IdStatutproject { get; set; }

        [JsonPropertyName("id_Energy_index")]
        public object? IdEnergyindex { get; set; }

        [JsonPropertyName("id_Address")]
        public ProjectAddress? Address { get; set; }

        [JsonPropertyName("id_PersonAgent")]
        public object? IdPersonAgent { get; set; }

        [JsonPropertyName("option_project")]
        public object? OptionProject { get; set; }

        [JsonPropertyName("room_project")]
        public object? RoomProject { get; set; }
    }
}
