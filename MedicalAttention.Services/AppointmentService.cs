namespace MedicalAttention.Services
{
    using MedicalAttention.Entities;
    using MedicalAttention.Entities.Enumerations;
    using MedicalAttention.Repositories;
    using MedicalAttention.Utilities.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AppointmentService : IAppointmentService
    {
        /// <summary>
        /// Represents the repository for the appointment.
        /// </summary>
        IAppointmentRepository repository;

        /// <summary>
        /// Represents a service for the patient.
        /// </summary>
        IPatientService patientService;
        
        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="repository">Repository for the appointment.</param>
        public AppointmentService(IAppointmentRepository repository, IPatientService patientService)
        {
            this.repository = repository;
            this.patientService = patientService;
        }

        /// <summary>
        /// Get all the appointments stored.
        /// </summary>
        /// <returns>List of the appointments.</returns>
        public List<Appointment> GetAppointments()
        {
            return repository.GetAppointments();
        }

        /// <summary>
        /// Get an appointment.
        /// </summary>
        /// <param name="id">Id of the appointment to get.</param>
        /// <returns>An appointment.</returns>
        public Appointment GetAppointment(int id)
        {
            return repository.GetAppointment(id);
        }

        /// <summary>
        /// Create an appointment.
        /// </summary>
        /// <param name="appointment">Appointment to create.</param>
        public void CreateAppointment(Appointment appointment)
        {
            ValidateDate(appointment);
            var appointments = repository.GetDoctorAppointments(appointment.Doctor.Id);
            foreach (Appointment doctorAppointment in appointments)
            {
                if (doctorAppointment.Date.Year == appointment.Date.Year &&
                    doctorAppointment.Date.Month == appointment.Date.Month &&
                    doctorAppointment.Date.Day == appointment.Date.Day &&
                    doctorAppointment.Date.Hour == appointment.Date.Hour &&
                    doctorAppointment.Date.Minute == appointment.Date.Minute &&
                    doctorAppointment.State.Id == (int)StateEnum.Assigned)
                {
                    throw new NotValidDateException("El doctor ya tiene asignada esa fecha de atención");
                }
            }

            repository.CreateAppointment(appointment);
        }

        /// <summary>
        /// Update an appointment.
        /// </summary>
        /// <param name="appointment">Appointment to update.</param>
        public void UpdateAppointment(Appointment appointment)
        {
            ValidateDate(appointment);
            var appointments = repository.GetDoctorAppointments(appointment.Doctor.Id);
            foreach (Appointment doctorAppointment in appointments)
            {
                if (doctorAppointment.Date.Year == appointment.Date.Year &&
                    doctorAppointment.Date.Month == appointment.Date.Month &&
                    doctorAppointment.Date.Day == appointment.Date.Day &&
                    doctorAppointment.Date.Hour == appointment.Date.Hour &&
                    doctorAppointment.Date.Minute == appointment.Date.Minute &&
                    doctorAppointment.Id != appointment.Id &&
                    doctorAppointment.State.Id == (int)StateEnum.Assigned)
                {
                    throw new NotValidDateException("El doctor ya tiene asignada esa fecha de atención");
                }
            }

            repository.UpdateAppointment(appointment);
        }

        /// <summary>
        /// Cancel an appointment.
        /// </summary>
        /// <param name="id">Id of the appointment to delete.</param>
        public void CancelAppointment(int id)
        {
            repository.CancelAppointment(id);
        }

        /// <summary>
        /// Get the available appointments of one doctor.
        /// </summary>
        /// <returns>List of the available appointments of one doctor.</returns>
        public List<Appointment> GetDoctorAvailableAppointments(int id)
        {
            var availableAppointments = new List<Appointment>();
            var appointments = repository.GetDoctorAppointments(id);

            DateTime date = DateTime.Now;
            int hour = date.Hour;
            if (date.Minute > 0)
            {
                hour++;
            }
            if (date.Hour > 18)
            {
                date = date.AddDays(1);
                hour = 8;
            }
            if (date.Hour < 8)
            {
                hour = 8;
            }

            date = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
            date = date.AddMinutes(-20);
            for (int i = 0; i < 30; i++)
            {
                for (int j = hour; j <= 18; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        date = date.AddMinutes(20);
                        var appointment = appointments.FirstOrDefault(a => a.Date.Year == date.Year &&
                            a.Date.Month == date.Month &&
                            a.Date.Day == date.Day &&
                            a.Date.Hour == date.Hour &&
                            a.Date.Minute == date.Minute);
                        if (appointment == null || (appointment != null && appointment.State.Id == (int)StateEnum.Cancelled))
                        {
                            availableAppointments.Add(new Appointment()
                            {
                                Date = date
                            });
                        }
                    }
                }
                date = date.AddDays(i);
            }

            return availableAppointments;

        }

        /// <summary>
        /// Get the asigned appointments of one doctor.
        /// </summary>
        /// <returns>List of the asigned appointments of one doctor.</returns>
        public List<Appointment> GetDoctorAsignedAppointments(int id)
        {
            var asignedAppointments = repository.GetDoctorAppointments(id);
            asignedAppointments = asignedAppointments.Where(a => a.State.Id == (int)StateEnum.Assigned).ToList();

            foreach(Appointment appointment in asignedAppointments)
            {
                appointment.Patient = patientService.GetPatient(appointment.Patient.Id);
            }

            return asignedAppointments;

        }

        private void ValidateDate(Appointment appointment)
        {
            if (appointment.Date < DateTime.Now)
            {
                throw new NotValidDateException("La fecha de la cita debe ser mayor a la fecha del sistema");
            }
            if (appointment.Date.Hour < 8 || appointment.Date.Hour > 18)
            {
                throw new NotValidDateException("La hora debe estar entre las 8:00 am y 6:00 pm");
            }
            if (appointment.Date.Minute != 0 && appointment.Date.Minute != 20 && appointment.Date.Minute != 40)
            {
                throw new NotValidDateException("Los minutos válidos para la hora son 0, 20 y 40");
            }
        }
    }
}
