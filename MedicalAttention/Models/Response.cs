namespace MedicalAttention.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Information of the response class.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Gets or sets if the operation was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary
        [JsonProperty(PropertyName = "error_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary
        [JsonProperty(PropertyName = "error_message")]
        public string ErrorMessage { get; set; }
        
    }
}