namespace MedicalAttention.Services
{
    using MedicalAttention.Entities;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Information of the patient repository interface.
    /// </summary>
    public interface IPatientService
    {
        /// <summary>
        /// Get all the patients stored.
        /// </summary>
        /// <returns>List of the patients.</returns>
        List<Patient> GetPatients();

        /// <summary>
        /// Get a patient.
        /// </summary>
        /// <param name="id">Id of the patient to get.</param>
        /// <returns>A patient.</returns>
        Patient GetPatient(int id);
    }
}
