namespace MedicalAttention.Utilities.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Class for not valid date exception.
    /// </summary>
    [Serializable]
    public class NotValidDateException : Exception
    {
        /// <summary>
        /// Empty Constructor.
        /// </summary>
        public NotValidDateException()
        {
        }

        /// <summary>
        /// Constructor with message.
        /// </summary>
        /// <param name="message">Error message.</param>
        public NotValidDateException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor with message and exception.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">Inner exception.</param>
        public NotValidDateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructor with info and context.
        /// </summary>
        /// <param name="info">Info of the exception.</param>
        /// <param name="context">Context of the exception.</param>
        protected NotValidDateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}