using MedicalAttention.Entities;
using MedicalAttention.Models;
using MedicalAttention.Services;
using MedicalAttention.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedicalAttention.Controllers
{
    public class AppointmentController : ApiController
    {
        /// <summary>
        /// Represents a service for the appointment.
        /// </summary>
        private IAppointmentService appointmentService;

        /// <summary>
        /// Constructor of the controller.
        /// </summary>
        /// <param name="appointmentService">Service of the appointment.</param>
        public AppointmentController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        // GET api/appointments
        [Route("api/appointments")]
        public AppointmentsResponse Get()
        {
            AppointmentsResponse response = new AppointmentsResponse() { Success = true };
            try
            {
                List<Appointment> appointments = appointmentService.GetAppointments();
                response.Appointments = appointments;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // GET api/appointments/5
        [Route("api/appointments/{id}")]
        public AppointmentResponse Get(int id)
        {
            AppointmentResponse response = new AppointmentResponse() { Success = true };
            try
            {
                var appointment = appointmentService.GetAppointment(id);
                if(appointment == null)
                {
                    throw new RecordNotFoundException(string.Format("Appointment {0} not found", id));
                }
                response.Appointment = appointment;
            }
            catch (RecordNotFoundException exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.RecordNotFound).ToString();
                response.ErrorMessage = exc.Message;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // POST api/appointments
        [Route("api/appointments")]
        public Response Post(Appointment appointment)
        {
            Response response = new Response() { Success = true };
            try
            {
                appointmentService.CreateAppointment(appointment);
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // PUT api/appointments/5
        [Route("api/appointments/{id}")]
        public Response Put(int id, Appointment appointment)
        {
            Response response = new Response() { Success = true };
            try
            {
                appointmentService.UpdateAppointment(id, appointment);
            }
            catch (RecordNotFoundException exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.RecordNotFound).ToString();
                response.ErrorMessage = exc.Message;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // PUT api/appointments/cancel/5
        [Route("api/appointments/cancel/{id}")]
        [HttpPut]
        public Response Cancel(int id)
        {
            Response response = new Response() { Success = true };
            try
            {
                appointmentService.CancelAppointment(id);
            }
            catch (RecordNotFoundException exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.RecordNotFound).ToString();
                response.ErrorMessage = exc.Message;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // GET api/appointments/availableAppointments/5
        [Route("api/appointments/availableAppointments/{id}")]
        public AppointmentsResponse GetDoctorAvailableAppointments(int id)
        {
            AppointmentsResponse response = new AppointmentsResponse() { Success = true };
            try
            {
                List<Appointment> appointments = appointmentService.GetDoctorAvailableAppointments(id);
                response.Appointments = appointments;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // GET api/appointments/asignedAppointments/5
        [Route("api/appointments/asignedAppointments/{id}")]
        public AppointmentsResponse GetDoctorAsignedAppointments(int id)
        {
            AppointmentsResponse response = new AppointmentsResponse() { Success = true };
            try
            {
                List<Appointment> appointments = appointmentService.GetDoctorAsignedAppointments(id);
                response.Appointments = appointments;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }
    }
}
