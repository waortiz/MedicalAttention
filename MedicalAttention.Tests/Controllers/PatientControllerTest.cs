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
    public class PatientControllerTest
    {
        private Mock<IPatientService> mockService = new Mock<IPatientService>();

        [TestMethod]
        public void GetPatient()
        {
            var patients = new List<Patient>();
            patients.Add(new Patient() { Id = 1 });
            patients.Add(new Patient() { Id = 2 });
            patients.Add(new Patient() { Id = 3 });

            mockService.Setup(x => x.GetPatients()).Returns(patients);

            var controller = new PatientController(mockService.Object);
            var response = controller.Get();
            CollectionAssert.AreEquivalent(patients, response.Patients);
        }

        [TestMethod]
        public void GetPatientById()
        {
            var appointment = new Patient() { Id = 1 };

            mockService.Setup(x => x.GetPatient(1)).Returns(appointment);

            var controller = new PatientController(mockService.Object);
            var response = controller.Get(1);
            Assert.AreEqual(1, response.Patient.Id);
        }

        [TestMethod]
        public void PatientNotFound()
        {
            var appointment = new Patient() { Id = 2 };

            mockService.Setup(x => x.GetPatient(2)).Returns(appointment);

            var controller = new PatientController(mockService.Object);
            var response = controller.Get(1);
            Assert.IsFalse(response.Success);
        }
    }
}
