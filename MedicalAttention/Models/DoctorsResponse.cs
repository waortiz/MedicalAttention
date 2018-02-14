namespace MedicalAttention.Models
{
    using MedicalAttention.Entities;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Class for the doctors response.
    /// </summary>
    public class DoctorsResponse : Response
    {
        /// <summary>
        /// Gets or sets the doctors.
        /// </summary>
        [JsonProperty(PropertyName = "doctors")]
        public List<Doctor> Doctors { get; set; }
    }
}