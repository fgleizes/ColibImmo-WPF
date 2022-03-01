using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColibImmo_WPF.API.JSON
{
    internal class PersonAppointment
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("id_Appointment")]
        public int IdAppointment { get; set; }

        [JsonPropertyName("id_Project")]
        public int IdProject { get; set; }

        [JsonPropertyName("project")]
        public Project? Project { get; set; }
    }
}
