namespace MedicalAttention.Models
{
    using MedicalAttention.Entities;
    using Newtonsoft.Json;

    /// <summary>
    /// Class for the specialty response.
    /// </summary>
    public class SpecialtyResponse : Response
    {
        /// <summary>
        /// Gets or sets the specialty.
        /// </summary>
        [JsonProperty(PropertyName = "specialty")]
        public Specialty Specialty { get; set; }
    }
}