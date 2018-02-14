namespace MedicalAttention.Models
{
    using MedicalAttention.Entities;
    using Newtonsoft.Json;

    /// <summary>
    /// Class for the patient response.
    /// </summary>
    public class PatientResponse : Response
    {
        /// <summary>
        /// Gets or sets the patient.
        /// </summary>
        [JsonProperty(PropertyName = "patient")]
        public Patient Patient { get; set; }
    }
}