namespace MedicalAttention.Services
{
    using MedicalAttention.Entities;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Information of the specialty repository interface.
    /// </summary>
    public interface ISpecialtyService
    {
        /// <summary>
        /// Get all the specialties stored.
        /// </summary>
        /// <returns>List of the specialties.</returns>
        List<Specialty> GetSpecialties();

        /// <summary>
        /// Get a specialty.
        /// </summary>
        /// <param name="id">Id of the specialty to get.</param>
        /// <returns>A specialty.</returns>
        Specialty GetSpecialty(int id);
    }
}
