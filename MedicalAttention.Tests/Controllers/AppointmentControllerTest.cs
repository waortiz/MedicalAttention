using MedicalAttention.Controllers;
using MedicalAttention.Entities;
using MedicalAttention.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace MedicalAttention.Tests.Controllers
{
    [TestClass]
    public class AppointmentControllerTest
    {
        private Mock<IAppointmentService> mockService = new Mock<IAppointmentService>();

        [TestMethod]
        public void GetAppointment()
        {
            List<Appointment> appointments = new List<Appointment>
            {
                new Appointment() { Id = 1 },
                new Appointment() { Id = 2 },
                new Appointment() { Id = 3 }
            };

            mockService.Setup(x => x.GetAppointments()).Returns(appointments);

            AppointmentController controller = new AppointmentController(mockService.Object);
            Models.AppointmentsResponse response = controller.Get();
            CollectionAssert.AreEquivalent(appointments, response.Appointments);
        }

        [TestMethod]
        public void GetAppointmentById()
        {
            Appointment appointment = new Appointment() { Id = 1 };

            mockService.Setup(x => x.GetAppointment(1)).Returns(appointment);

            AppointmentController controller = new AppointmentController(mockService.Object);
            Models.AppointmentResponse response = controller.Get(1);
            Assert.AreEqual(1, response.Appointment.Id);
        }

        [TestMethod]
        public void PostAppointment()
        {
            Appointment appointment = new Appointment() { Id = 1 };

            mockService.Setup(x => x.CreateAppointment(appointment));

            AppointmentController controller = new AppointmentController(mockService.Object);
            Models.Response response = controller.Post(appointment);
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public void PutAppointment()
        {
            Appointment appointment = new Appointment() { Id = 1 };

            mockService.Setup(x => x.UpdateAppointment(1, appointment));

            AppointmentController controller = new AppointmentController(mockService.Object);
            Models.Response response = controller.Put(1, appointment);
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public void CancelAppointment()
        {
            mockService.Setup(x => x.CancelAppointment(1));

            AppointmentController controller = new AppointmentController(mockService.Object);
            Models.Response response = controller.Cancel(1);
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public void AppointmentNotFound()
        {
            Appointment appointment = new Appointment() { Id = 2 };

            mockService.Setup(x => x.GetAppointment(2)).Returns(appointment);

            AppointmentController controller = new AppointmentController(mockService.Object);
            Models.AppointmentResponse response = controller.Get(1);
            Assert.IsFalse(response.Success);
        }
    }
}
