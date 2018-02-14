using Newtonsoft.Json;

namespace MedicalAttention.Entities
{
    public class State
    {
        /// <summary>
        /// Gets or sets the identifier of the state.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}