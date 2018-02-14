using MedicalAttention.Entities.Converters;
using System;

namespace MedicalAttention.Repositories.Model
{
    public class Appointment
    {
        /// <summary>
        /// Gets or sets the identifier of the appointment.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the patient id.
        /// </summary>
        public int PatientId { get; set; }

        /// <summary>
        /// Gets or sets the doctor id.
        /// </summary>
        public int DoctorId { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the state id.
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public virtual State State { get; set; }
    }
}
