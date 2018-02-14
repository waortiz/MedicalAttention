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
    public class DoctorController : ApiController
    {
        /// <summary>
        /// Represents a service for the doctor.
        /// </summary>
        private IDoctorService doctorService;

        /// <summary>
        /// Constructor of the controller.
        /// </summary>
        /// <param name="doctorService">Service of the doctor.</param>
        public DoctorController(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        // GET api/doctors
        [Route("api/doctors")]
        public DoctorsResponse Get()
        {
            DoctorsResponse response = new DoctorsResponse() { Success = true };
            try
            {
                List<Doctor> doctors = doctorService.GetDoctors();
                response.Doctors = doctors;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // GET api/doctors/5
        [Route("api/doctors/{id}")]
        public DoctorResponse Get(int id)
        {
            DoctorResponse response = new DoctorResponse() { Success = true };
            try
            {
                Doctor doctor = doctorService.GetDoctor(id);
                if (doctor == null)
                {
                    throw new RecordNotFoundException(string.Format("Doctor {0} not found", id));
                }
                response.Doctor = doctor;
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
