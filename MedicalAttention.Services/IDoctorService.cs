namespace MedicalAttention.Services
{
    using MedicalAttention.Entities;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Information of the doctor repository interface.
    /// </summary>
    public interface IDoctorService
    {
        /// <summary>
        /// Get all the doctors stored.
        /// </summary>
        /// <returns>List of the doctors.</returns>
        List<Doctor> GetDoctors();

        /// <summary>
        /// Get a doctor.
        /// </summary>
        /// <param name="id">Id of the doctor to get.</param>
        /// <returns>A doctor.</returns>
        Doctor GetDoctor(int id);
    }
}
