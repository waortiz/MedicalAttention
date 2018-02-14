using Newtonsoft.Json;

namespace MedicalAttention.Entities
{
    public class Specialty
    {
        /// <summary>
        /// Gets or sets the identifier of the specialty.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the specialty type.
        /// </summary>
        [JsonProperty(PropertyName = "specialty_type")]
        public string SpecialtyType { get; set; }
    }
}