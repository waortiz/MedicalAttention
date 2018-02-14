namespace MedicalAttention.Models
{
    using MedicalAttention.Entities;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Class for the patients response.
    /// </summary>
    public class PatientsResponse : Response
    {
        /// <summary>
        /// Gets or sets the patients.
        /// </summary>
        [JsonProperty(PropertyName = "patients")]
        public List<Patient> Patients { get; set; }
    }
}