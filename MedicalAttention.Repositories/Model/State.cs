using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAttention.Repositories.Model
{
    public class State
    {
        /// <summary>
        /// Gets or sets the identifier of the state.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}