namespace MedicalAttention.Services
{
    using MedicalAttention.Entities;
    using System.Collections.Generic;

    /// <summary>
    /// Information of the appointment repository interface.
    /// </summary>
    public interface IAppointmentService
    {
        /// <summary>
        /// Get all the appointments stored.
        /// </summary>
        /// <returns>List of the appointments.</returns>
        List<Appointment> GetAppointments();

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
        /// <param name="id">Id of the appointment to cancel.</param>
        void CancelAppointment(int id);

        /// <summary>
        /// Get the available appointments of one doctor.
        /// </summary>
        /// <returns>List of the available appointments of one doctor.</returns>
        List<Appointment> GetDoctorAvailableAppointments(int id);

        /// <summary>
        /// Get the asigned appointments of one doctor.
        /// </summary>
        /// <returns>List of the asigned appointments of one doctor.</returns>
        List<Appointment> GetDoctorAsignedAppointments(int id);
    }
}
