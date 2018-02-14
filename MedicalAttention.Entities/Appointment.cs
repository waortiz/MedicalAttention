using MedicalAttention.Entities.Converters;
using Newtonsoft.Json;
using System;

namespace MedicalAttention.Entities
{
    public class Appointment
    {
        /// <summary>
        /// Gets or sets the identifier of the appointment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the patient.
        /// </summary>
        [JsonProperty(PropertyName = "patient")]
        public Patient Patient { get; set; }

        /// <summary>
        /// Gets or sets the doctor.
        /// </summary>
        [JsonProperty(PropertyName = "doctor")]
        public Doctor Doctor { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        [JsonProperty(PropertyName = "date")]
        [JsonConverter(typeof(DateFormatConverter), "MM/dd/yyyy HH:mm")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public State State { get; set; }
    }
}
