namespace MedicalAttention.Repositories
{
    public abstract class BaseRepository
    {
        /// <summary>
        /// Represents a context for database operations.
        /// </summary>
        internal MedicalAttentionContext medicalAttentionContext;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="superShoesContext">Context for database operations</param>
        public BaseRepository(MedicalAttentionContext medicalAttentionContext)
        {
            this.medicalAttentionContext = medicalAttentionContext;
        }
    }
}