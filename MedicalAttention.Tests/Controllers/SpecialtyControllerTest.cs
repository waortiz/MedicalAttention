using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedicalAttention;
using MedicalAttention.Controllers;
using MedicalAttention.App_Start;
using MedicalAttention.Services;
using Moq;
using MedicalAttention.Entities;

namespace MedicalAttention.Tests.Controllers
{
    [TestClass]
    public class SpecialtyControllerTest
    {
        private Mock<ISpecialtyService> mockService = new Mock<ISpecialtyService>();

        [TestMethod]
        public void GetSpecialty()
        {
            var specialties = new List<Specialty>();
            specialties.Add(new Specialty() { Id = 1 });
            specialties.Add(new Specialty() { Id = 2 });
            specialties.Add(new Specialty() { Id = 3 });

            mockService.Setup(x => x.GetSpecialties()).Returns(specialties);

            var controller = new SpecialtyController(mockService.Object);
            var response = controller.Get();
            CollectionAssert.AreEquivalent(specialties, response.Specialties);
        }

        [TestMethod]
        public void GetSpecialtyById()
        {
            var specialty = new Specialty() { Id = 1 };

            mockService.Setup(x => x.GetSpecialty(1)).Returns(specialty);

            var controller = new SpecialtyController(mockService.Object);
            var response = controller.Get(1);
            Assert.AreEqual(1, response.Specialty.Id);
        }

        [TestMethod]
        public void SpecialtyNotFound()
        {
            var specialty = new Specialty() { Id = 2 };

            mockService.Setup(x => x.GetSpecialty(2)).Returns(specialty);

            var controller = new SpecialtyController(mockService.Object);
            var response = controller.Get(1);
            Assert.IsFalse(response.Success);
        }
    }
}
