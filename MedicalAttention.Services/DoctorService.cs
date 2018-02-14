namespace MedicalAttention.Services
{
    using MedicalAttention.Entities;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Text;

    public class DoctorService : IDoctorService
    {
        /// <summary>
        /// Represents the client rest service for the doctor.
        /// </summary>
        private RestClient client;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        public DoctorService()
        {
            this.client = new RestClient() { BaseUrl = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]) };
        }

        /// <summary>
        /// Get all the doctors stored.
        /// </summary>
        /// <returns>List of the doctors.</returns>
        public List<Doctor> GetDoctors()
        {
            RestRequest request = new RestRequest("doctors", Method.GET) { RequestFormat = DataFormat.Json};
            var doctors = this.client.Execute<List<Doctor>>(request);

            return doctors.Data;
        }

        /// <summary>
        /// Get an doctor.
        /// </summary>
        /// <param name="doctorId">Id of the doctor to get.</param>
        /// <returns>An doctor.</returns>
        public Doctor GetDoctor(int doctorId)
        {
            RestRequest request = new RestRequest("doctors/" + doctorId, Method.GET) { RequestFormat = DataFormat.Json };
            var doctor = this.client.Execute<Doctor>(request);

            return doctor.Data;
        }
    }
}
