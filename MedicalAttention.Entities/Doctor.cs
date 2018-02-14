using Newtonsoft.Json;
using RestSharp.Deserializers;

namespace MedicalAttention.Entities
{
    public class Doctor
    {
        /// <summary>
        /// Gets or sets the identifier of the doctor.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identification.
        /// </summary>
        [JsonProperty(PropertyName = "identification")]
        public string Identification { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the blood type.
        /// </summary>
        [JsonProperty(PropertyName = "blood_type")]
        public string BloodType { get; set; }
        
        /// <summary>
        /// Gets or sets the Specialty.
        /// </summary>
        [JsonProperty(PropertyName = "specialty_field")]
        [DeserializeAs(Name = "specialty_field")]
        public Specialty Specialty { get; set; }
    }
}
