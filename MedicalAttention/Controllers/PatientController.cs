using MedicalAttention.Entities;
using MedicalAttention.Models;
using MedicalAttention.Services;
using MedicalAttention.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MedicalAttention.Controllers
{
    public class PatientController : ApiController
    {
        /// <summary>
        /// Represents a service for the patient.
        /// </summary>
        private IPatientService patientService;

        /// <summary>
        /// Constructor of the controller.
        /// </summary>
        /// <param name="patientService">Service of the patient.</param>
        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        // GET api/patients
        [Route("api/patients")]
        public PatientsResponse Get()
        {
            PatientsResponse response = new PatientsResponse() { Success = true };
            try
            {
                List<Patient> patients = patientService.GetPatients();
                response.Patients = patients;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // GET api/patients/5
        [Route("api/patients/{id}")]
        public PatientResponse Get(int id)
        {
            PatientResponse response = new PatientResponse() { Success = true };
            try
            {
                Patient patient = patientService.GetPatient(id);
                if (patient == null)
                {
                    throw new RecordNotFoundException(string.Format("Patient {0} not found", id));
                }

                response.Patient = patient;
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
