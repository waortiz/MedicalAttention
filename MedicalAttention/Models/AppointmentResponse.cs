namespace MedicalAttention.Models
{
    using MedicalAttention.Entities;
    using Newtonsoft.Json;

    /// <summary>
    /// Class for the appointment response.
    /// </summary>
    public class AppointmentResponse : Response
    {
        /// <summary>
        /// Gets or sets the appointment.
        /// </summary>
        [JsonProperty(PropertyName = "appointment")]
        public Appointment Appointment { get; set; }
    }
}