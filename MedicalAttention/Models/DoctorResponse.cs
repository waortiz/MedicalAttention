namespace MedicalAttention.Models
{
    using MedicalAttention.Entities;
    using Newtonsoft.Json;

    /// <summary>
    /// Class for the doctor response.
    /// </summary>
    public class DoctorResponse : Response
    {
        /// <summary>
        /// Gets or sets the doctor.
        /// </summary>
        [JsonProperty(PropertyName = "doctor")]
        public Doctor Doctor { get; set; }
    }
}