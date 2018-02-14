using MedicalAttention.Entities;
using MedicalAttention.Models;
using MedicalAttention.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedicalAttention.Controllers
{
    public class SpecialtyController : ApiController
    {
        /// <summary>
        /// Represents a service for the specialty.
        /// </summary>
        private ISpecialtyService specialtyService;

        /// <summary>
        /// Constructor of the controller.
        /// </summary>
        /// <param name="specialtyService">Service of the specialtie.</param>
        public SpecialtyController(ISpecialtyService specialtyService)
        {
            this.specialtyService = specialtyService;
        }

        // GET api/specialties
        public SpecialtiesResponse Get()
        {
            SpecialtiesResponse response = new SpecialtiesResponse() { Success = true };
            try
            {
                List<Specialty> specialties = specialtyService.GetSpecialties();
                response.Specialties = specialties;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // GET api/specialties/5
        public SpecialtyResponse Get(int id)
        {
            SpecialtyResponse response = new SpecialtyResponse() { Success = true };
            try
            {
                Specialty specialty = specialtyService.GetSpecialty(id);
                response.Specialty = specialty;
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
