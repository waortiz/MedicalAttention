namespace MedicalAttention.Repositories
{
    using MedicalAttention.Entities;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Interface for managing the repository of the appointment.
    /// </summary>
    public interface IAppointmentRepository
    {
        /// <summary>
        /// Get all the appointments stored.
        /// </summary>
        /// <returns>List of the appointments.</returns>
        List<Appointment> GetAppointments();

        /// <summary>
        /// Get the doctor's appointments.
        /// </summary>
        /// <returns>List of the appointments.</returns>
        List<Appointment> GetDoctorAppointments(int id);

        /// <summary>
        /// Get an appointment.
        /// </summary>
        /// <param name="id">Id of the appointment to get.</param>
        /// <returns>An appointment.</returns>
        Appointment GetAppointment(int id);

        /// <summary>
        /// Create an appointment.
        /// </summary>
        /// <param name="appointment">Appointment to create.</param>
        void CreateAppointment(Appointment appointment);

        /// <summary>
        /// Update an appointment.
        /// </summary>
        /// <param name="id">Id of the appointment</param>
        /// <param name="appointment">Appointment to update.</param>
        void UpdateAppointment(int id, Appointment appointment);

        /// <summary>
        /// Cancel an appointment.
        /// </summary>
        /// <param name="appointmentId">Id of the appointment to cancel.</param>
        void CancelAppointment(int id);
    }
}
