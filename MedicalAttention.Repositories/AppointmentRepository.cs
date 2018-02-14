namespace MedicalAttention.Repositories
{
    using MedicalAttention.Entities;
    using MedicalAttention.Entities.Enumerations;
    using MedicalAttention.Utilities.Exceptions;
    using MedicalAttention.Repositories;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    /// <summary>
    /// Class for managing the repository of the appointment
    /// </summary>
    public class AppointmentRepository : BaseRepository, IAppointmentRepository
    {
        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="medicalAttentionContext">Context for database operations</param>
        public AppointmentRepository(MedicalAttentionContext medicalAttentionContext) : base(medicalAttentionContext)
        {

        }

        /// <summary>
        /// Get all the appointments stored.
        /// </summary>
        /// <returns>List of the appointments.</returns>
        public List<Appointment> GetAppointments()
        {
            List<Appointment> appointments = medicalAttentionContext.Appointments.Select(a => new Appointment()
            {
                Id = a.Id,
                Date = a.Date,
                Doctor = new Doctor()
                {
                    Id = a.DoctorId,
                },
                Patient = new Patient()
                {
                    Id = a.PatientId
                },
                State = new State()
                {
                    Id = a.State.Id,
                    Name = a.State.Name
                }
            }).ToList();

            return appointments;
        }

        /// <summary>
        /// Get the doctor's appointments.
        /// </summary>
        /// <returns>List of the appointments.</returns>
        public List<Appointment> GetDoctorAppointments(int id)
        {
            List<Appointment> appointments = medicalAttentionContext.Appointments.Where(a => a.DoctorId == id).Select(a => new Appointment()
            {
                Id = a.Id,
                Date = a.Date,
                Doctor = new Doctor()
                {
                    Id = a.DoctorId,
                },
                Patient = new Patient()
                {
                    Id = a.PatientId
                },
                State = new State()
                {
                    Id = a.State.Id,
                    Name = a.State.Name
                }
            }).ToList();

            return appointments;
        }

        /// <summary>
        /// Get an appointment.
        /// </summary>
        /// <param name="id">Id of the appointment to get.</param>
        /// <returns>An appointment.</returns>
        public Appointment GetAppointment(int id)
        {
            var currentAppointment = medicalAttentionContext.Appointments.Find(id);
            if (currentAppointment == null)
            {
                throw new RecordNotFoundException(string.Format("Appointment {0} not found", id));
            }

            Appointment appointment = new Appointment()
            {
                Id = currentAppointment.Id,
                Date = currentAppointment.Date,
                Doctor = new Doctor()
                {
                    Id = currentAppointment.DoctorId
                },
                Patient = new Patient()
                {
                    Id = currentAppointment.PatientId
                },
                State = new State()
                {
                    Id = currentAppointment.State.Id,
                    Name = currentAppointment.State.Name
                }
            };

            return appointment;
        }

        /// <summary>
        /// Create an appointment.
        /// </summary>
        /// <param name="appointment">Appointment to create.</param>
        public void CreateAppointment(Appointment appointment)
        {
            var newAppointment = new Model.Appointment()
            {
                Date = appointment.Date,
                DoctorId = appointment.Doctor.Id,
                PatientId = appointment.Patient.Id,
                StateId = (int)StateEnum.Assigned
            };

            medicalAttentionContext.Appointments.Add(newAppointment);
            medicalAttentionContext.SaveChanges();
        }

        /// <summary>
        /// Update an appointment.
        /// </summary>
        /// <param name="id">Id of the appointment</param>
        /// <param name="appointment">Appointment to update.</param>
        public void UpdateAppointment(int id, Appointment appointment)
        {
            var currentAppointment = medicalAttentionContext.Appointments.FirstOrDefault(a => a.Id == id);
            if (currentAppointment != null)
            {
                currentAppointment.Date = appointment.Date;
                currentAppointment.DoctorId = appointment.Doctor.Id;
                currentAppointment.PatientId = appointment.Patient.Id;

                medicalAttentionContext.SaveChanges();
            }
            else
            {
                throw new RecordNotFoundException(string.Format("Appointment {0} not found", appointment.Id));
            }

            medicalAttentionContext.SaveChanges();
        }

        /// <summary>
        /// Cancel an appointment.
        /// </summary>
        /// <param name="id">Id of the appointment to cancel.</param>
        public void CancelAppointment(int id)
        {
            var currentAppointment = medicalAttentionContext.Appointments.Find(id);
            if (currentAppointment != null)
            {
                currentAppointment.StateId = (int)StateEnum.Cancelled;
                medicalAttentionContext.SaveChanges();
            }
            else
            {
                throw new RecordNotFoundException(string.Format("Appointment {0} not found", id));
            }
        }
    }
}
