namespace MedicalAttention.Services
{
    using MedicalAttention.Entities;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Text;

    public class PatientService : IPatientService
    {
        /// <summary>
        /// Represents the client rest service for the patient.
        /// </summary>
        private RestClient client;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        public PatientService()
        {
            this.client = new RestClient() { BaseUrl = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]) };
        }

        /// <summary>
        /// Get all the patients stored.
        /// </summary>
        /// <returns>List of the patients.</returns>
        public List<Patient> GetPatients()
        {
            RestRequest request = new RestRequest("patients", Method.GET) { RequestFormat = DataFormat.Json};
            var patients = this.client.Execute<List<Patient>>(request);

            return patients.Data;
        }

        /// <summary>
        /// Get an patient.
        /// </summary>
        /// <param name="patientId">Id of the patient to get.</param>
        /// <returns>An patient.</returns>
        public Patient GetPatient(int patientId)
        {
            RestRequest request = new RestRequest("patients/" + patientId, Method.GET) { RequestFormat = DataFormat.Json };
            var patient = this.client.Execute<Patient>(request);

            return patient.Data;
        }
    }
}
