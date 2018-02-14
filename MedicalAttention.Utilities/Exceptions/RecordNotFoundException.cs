namespace MedicalAttention.Utilities.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Class for record not found exception.
    /// </summary>
    [Serializable]
    public class RecordNotFoundException : Exception
    {
        /// <summary>
        /// Empty Constructor.
        /// </summary>
        public RecordNotFoundException()
        {
        }

        /// <summary>
        /// Constructor with message.
        /// </summary>
        /// <param name="message">Error message.</param>
        public RecordNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor with message and exception.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">Inner exception.</param>
        public RecordNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructor with info and context.
        /// </summary>
        /// <param name="info">Info of the exception.</param>
        /// <param name="context">Context of the exception.</param>
        protected RecordNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}