namespace MedicalAttention.Models
{
    using MedicalAttention.Entities;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Class for the specialties response.
    /// </summary>
    public class SpecialtiesResponse : Response
    {
        /// <summary>
        /// Gets or sets the specialties.
        /// </summary>
        [JsonProperty(PropertyName = "specialties")]
        public List<Specialty> Specialties { get; set; }
    }
}