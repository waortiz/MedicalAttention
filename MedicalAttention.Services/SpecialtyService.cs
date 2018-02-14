namespace MedicalAttention.Services
{
    using MedicalAttention.Entities;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Text;

    public class SpecialtyService : ISpecialtyService
    {
        /// <summary>
        /// Represents the client rest service for the specialty.
        /// </summary>
        private RestClient client;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        public SpecialtyService()
        {
            this.client = new RestClient() { BaseUrl = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]) };
        }

        /// <summary>
        /// Get all the specialtys stored.
        /// </summary>
        /// <returns>List of the specialtys.</returns>
        public List<Specialty> GetSpecialties()
        {
            RestRequest request = new RestRequest("specialties", Method.GET) { RequestFormat = DataFormat.Json};
            var result = this.client.Execute<List<Specialty>>(request);
           
            return result.Data;
        }

        /// <summary>
        /// Get an specialty.
        /// </summary>
        /// <param name="specialtyId">Id of the specialty to get.</param>
        /// <returns>An specialty.</returns>
        public Specialty GetSpecialty(int specialtyId)
        {
            RestRequest request = new RestRequest("specialties/" + specialtyId, Method.GET) { RequestFormat = DataFormat.Json };
            var result = this.client.Execute<Specialty>(request);

            return result.Data;
        }
    }
}
