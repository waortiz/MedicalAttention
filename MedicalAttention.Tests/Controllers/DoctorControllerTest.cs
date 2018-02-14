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
    public class DoctorControllerTest
    {
        private Mock<IDoctorService> mockService = new Mock<IDoctorService>();

        [TestMethod]
        public void GetDoctor()
        {
            var doctors = new List<Doctor>();
            doctors.Add(new Doctor() { Id = 1 });
            doctors.Add(new Doctor() { Id = 2 });
            doctors.Add(new Doctor() { Id = 3 });

            mockService.Setup(x => x.GetDoctors()).Returns(doctors);

            var controller = new DoctorController(mockService.Object);
            var response = controller.Get();
            CollectionAssert.AreEquivalent(doctors, response.Doctors);
        }

        [TestMethod]
        public void GetDoctorById()
        {
            var appointment = new Doctor() { Id = 1 };

            mockService.Setup(x => x.GetDoctor(1)).Returns(appointment);

            var controller = new DoctorController(mockService.Object);
            var response = controller.Get(1);
            Assert.AreEqual(1, response.Doctor.Id);
        }

        [TestMethod]
        public void DoctorNotFound()
        {
            var appointment = new Doctor() { Id = 2 };

            mockService.Setup(x => x.GetDoctor(2)).Returns(appointment);

            var controller = new DoctorController(mockService.Object);
            var response = controller.Get(1);
            Assert.IsFalse(response.Success);
        }
    }
}
