namespace MedicalAttention.Models
{
    using MedicalAttention.Entities;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Class for the appointments response.
    /// </summary>
    public class AppointmentsResponse : Response
    {
        /// <summary>
        /// Gets or sets the appointments.
        /// </summary>
        [JsonProperty(PropertyName = "appointments")]
        public List<Appointment> Appointments { get; set; }
    }
}