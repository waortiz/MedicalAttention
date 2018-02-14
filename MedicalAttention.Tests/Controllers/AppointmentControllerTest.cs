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
    public class AppointmentControllerTest
    {
        private Mock<IAppointmentService> mockService = new Mock<IAppointmentService>();

        [TestMethod]
        public void GetAppointment()
        {
            var appointments = new List<Appointment>();
            appointments.Add(new Appointment() { Id = 1 });
            appointments.Add(new Appointment() { Id = 2 });
            appointments.Add(new Appointment() { Id = 3 });

            mockService.Setup(x => x.GetAppointments()).Returns(appointments);

            var controller = new AppointmentController(mockService.Object);
            var response = controller.Get();
            CollectionAssert.AreEquivalent(appointments, response.Appointments);
        }

        [TestMethod]
        public void GetAppointmentById()
        {
            var appointment = new Appointment() { Id = 1 };

            mockService.Setup(x => x.GetAppointment(1)).Returns(appointment);

            var controller = new AppointmentController(mockService.Object);
            var response = controller.Get(1);
            Assert.AreEqual(1, response.Appointment.Id);
        }

        [TestMethod]
        public void PostAppointment()
        {
            var appointment = new Appointment() { Id = 1 };

            mockService.Setup(x => x.CreateAppointment(appointment));

            var controller = new AppointmentController(mockService.Object);
            var response = controller.Post(appointment);
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public void PutAppointment()
        {
            var appointment = new Appointment() { Id = 1 };

            mockService.Setup(x => x.UpdateAppointment(1, appointment));

            var controller = new AppointmentController(mockService.Object);
            var response = controller.Put(1, appointment);
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public void CancelAppointment()
        {
            mockService.Setup(x => x.CancelAppointment(1));

            var controller = new AppointmentController(mockService.Object);
            var response = controller.Cancel(1);
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public void AppointmentNotFound()
        {
            var appointment = new Appointment() { Id = 2 };

            mockService.Setup(x => x.GetAppointment(2)).Returns(appointment);

            var controller = new AppointmentController(mockService.Object);
            var response = controller.Get(1);
            Assert.IsFalse(response.Success);
        }
    }
}
