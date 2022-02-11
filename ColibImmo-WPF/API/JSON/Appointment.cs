using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ColibImmo_WPF.API.JSON
{
    internal class Appointment
    {
        [JsonPropertyName("subject")]
        public string? Subject { get; set; }

        [JsonPropertyName("start_datetime")]
        public string? Start { get; set; }

        [JsonPropertyName("end_datetime")]
        public string? End { get; set; }

        //public string StartEnd = DateTime.Parse(Start);

        public override string ToString()
        {
            return this.Start + ", " + this.End;
        }

        [JsonPropertyName("is_canceled")]
        public string? IsCanceled { get; set; }

        [JsonPropertyName("created_at")]
        public string? CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public string? UpdatedAt { get; set; }

        [JsonPropertyName("person_appointment")]
        public List<PersonAppointment>? PersonAppointment { get; set; }
        public string? AppointmentHour { get; internal set; }
        public string? AppointmentDate { get; internal set; }
    }
}
