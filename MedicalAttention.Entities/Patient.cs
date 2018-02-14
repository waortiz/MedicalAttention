using MedicalAttention.Entities.Converters;
using Newtonsoft.Json;
using System;

namespace MedicalAttention.Entities
{
    public class Patient
    {
        /// <summary>
        /// Gets or sets the identifier of the patient.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the history.
        /// </summary>
        [JsonProperty(PropertyName = "history")]
        public string History { get; set; }

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
        /// Gets or sets the genre.
        /// </summary>
        [JsonProperty(PropertyName = "genre")]
        public string Genre { get; set; }

        /// <summary>
        /// Gets or sets the civil status.
        /// </summary>
        [JsonProperty(PropertyName = "civil_status")]
        public string CivilStatus { get; set; }

        /// <summary>
        /// Gets or sets the blood type.
        /// </summary>
        [JsonProperty(PropertyName = "blood type")]
        public string BloodType { get; set; }

        /// <summary>
        /// Gets or sets the date birth.
        /// </summary>
        [JsonProperty(PropertyName = "date_birth")]
        [JsonConverter(typeof(DateFormatConverter), "MM/dd/yyyy")]
        public DateTime DateBirth { get; set; }

        /// <summary>
        /// Gets or sets the city birth.
        /// </summary>
        [JsonProperty(PropertyName = "city_birth")]
        public string CityBirth { get; set; }
    }
}
