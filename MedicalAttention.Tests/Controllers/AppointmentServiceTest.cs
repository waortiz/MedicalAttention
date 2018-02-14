using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedicalAttention;
using MedicalAttention.Controllers;
using MedicalAttention.Services;
using Moq;
using MedicalAttention.Entities;
using MedicalAttention.Repositories;
using MedicalAttention.Utilities.Exceptions;
using MedicalAttention.Entities.Enumerations;

namespace MedicalAttention.Tests.Controllers
{
    [TestClass]
    public class AppointmentServiceTest
    {
        private Mock<IAppointmentRepository> mockRepository = new Mock<IAppointmentRepository>();
        private Mock<IPatientService> mockPatientService = new Mock<IPatientService>();
        private Mock<IDoctorService> mockDoctorService = new Mock<IDoctorService>();

        [TestMethod]
        [ExpectedException(typeof(NotValidDateException), "The appointment has already been assigned.")]
        public void CreateAppointmentAlreadyAssigned()
        {
            var appointments = new List<Appointment>();
            appointments.Add(new Appointment() { Id = 1, Date = new DateTime(2018, 3, 1, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 2, Date = new DateTime(2018, 3, 2, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 3, Date = new DateTime(2018, 3, 2, 10, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });

            mockRepository.Setup(x => x.GetDoctorAppointments(1)).Returns(appointments);

            var service = new AppointmentService(mockRepository.Object, mockPatientService.Object, mockDoctorService.Object);
            service.CreateAppointment(new Appointment() { Id = 3, Date = new DateTime(2018, 3, 2, 10, 20, 0), Doctor = new Doctor() { Id = 1 } });
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidDateException), "The date of the appointment is not valid.")]
        public void CreateNotValidAppointment()
        {
            var appointments = new List<Appointment>();
            appointments.Add(new Appointment() { Id = 1, Date = new DateTime(2018, 3, 1, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 2, Date = new DateTime(2018, 3, 2, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 3, Date = new DateTime(2018, 3, 2, 10, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });

            mockRepository.Setup(x => x.GetDoctorAppointments(1)).Returns(appointments);

            var service = new AppointmentService(mockRepository.Object, mockPatientService.Object, mockDoctorService.Object);
            service.CreateAppointment(new Appointment() { Id = 3, Date = new DateTime(2018, 3, 2, 10, 30, 0), Doctor = new Doctor() { Id = 1 } });
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidDateException), "The appointment has already passed.")]
        public void CreateAppointmentWithAPastDate()
        {
            var appointments = new List<Appointment>();
            appointments.Add(new Appointment() { Id = 1, Date = new DateTime(2018, 3, 1, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 2, Date = new DateTime(2018, 3, 2, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 3, Date = new DateTime(2018, 3, 2, 10, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });

            mockRepository.Setup(x => x.GetDoctorAppointments(1)).Returns(appointments);

            var service = new AppointmentService(mockRepository.Object, mockPatientService.Object, mockDoctorService.Object);
            service.CreateAppointment(new Appointment() { Id = 3, Date = new DateTime(2017, 3, 2, 10, 20, 0), Doctor = new Doctor() { Id = 1 } });
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidDateException), "The hour of the appointment is not valid.")]
        public void CreateAppointmentWithAInvalidHour()
        {
            var appointments = new List<Appointment>();
            appointments.Add(new Appointment() { Id = 1, Date = new DateTime(2018, 3, 1, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 2, Date = new DateTime(2018, 3, 2, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 3, Date = new DateTime(2018, 3, 2, 10, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });

            mockRepository.Setup(x => x.GetDoctorAppointments(1)).Returns(appointments);

            var service = new AppointmentService(mockRepository.Object, mockPatientService.Object, mockDoctorService.Object);
            service.CreateAppointment(new Appointment() { Id = 3, Date = new DateTime(2017, 3, 2, 3, 20, 0), Doctor = new Doctor() { Id = 1 } });
        }

        [TestMethod]
        public void CreateValidAppointment()
        {
            var appointments = new List<Appointment>();
            appointments.Add(new Appointment() { Id = 1, Date = new DateTime(2018, 3, 1, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 2, Date = new DateTime(2018, 3, 2, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 3, Date = new DateTime(2018, 3, 2, 10, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });

            mockRepository.Setup(x => x.GetDoctorAppointments(1)).Returns(appointments);
            mockDoctorService.Setup(x => x.GetDoctor(1)).Returns(new Doctor() { Id = 1 });

            var service = new AppointmentService(mockRepository.Object, mockPatientService.Object, mockDoctorService.Object);
            service.CreateAppointment(new Appointment() { Id = 3, Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 20, 0), Doctor = new Doctor() { Id = 1 } });
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidDateException), "The appointment has already passed.")]
        public void UpdateAppointmentWithAPastDate()
        {
            var appointments = new List<Appointment>();
            appointments.Add(new Appointment() { Id = 1, Date = new DateTime(2018, 3, 1, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 2, Date = new DateTime(2018, 3, 2, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 3, Date = new DateTime(2018, 3, 2, 10, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });

            mockRepository.Setup(x => x.GetDoctorAppointments(1)).Returns(appointments);

            var service = new AppointmentService(mockRepository.Object, mockPatientService.Object, mockDoctorService.Object);
            service.UpdateAppointment(3, new Appointment() { Id = 3, Date = new DateTime(2017, 3, 2, 10, 20, 0), Doctor = new Doctor() { Id = 1 } });
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidDateException), "The hour of the appointment is not valid.")]
        public void UpdateAppointmentWithAInvalidHour()
        {
            var appointments = new List<Appointment>();
            appointments.Add(new Appointment() { Id = 1, Date = new DateTime(2018, 3, 1, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 2, Date = new DateTime(2018, 3, 2, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 3, Date = new DateTime(2018, 3, 2, 10, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });

            mockRepository.Setup(x => x.GetDoctorAppointments(1)).Returns(appointments);

            var service = new AppointmentService(mockRepository.Object, mockPatientService.Object, mockDoctorService.Object);
            service.UpdateAppointment(3, new Appointment() { Id = 3, Date = new DateTime(2017, 3, 2, 3, 20, 0), Doctor = new Doctor() { Id = 1 } });
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotValidDateException), "The minutes of the appointment are not valid.")]
        public void UpdateNotValidAppointment()
        {
            var appointments = new List<Appointment>();
            appointments.Add(new Appointment() { Id = 1, Date = new DateTime(2018, 3, 1, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 2, Date = new DateTime(2018, 3, 2, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 3, Date = new DateTime(2018, 3, 2, 10, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });

            mockRepository.Setup(x => x.GetDoctorAppointments(1)).Returns(appointments);

            var service = new AppointmentService(mockRepository.Object, mockPatientService.Object, mockDoctorService.Object);
            service.UpdateAppointment(3, new Appointment() { Id = 3, Date = new DateTime(2018, 3, 2, 10, 30, 0), Doctor = new Doctor() { Id = 1 } });
        }

        [TestMethod]
        public void UpdateValidAppointment()
        {
            var appointments = new List<Appointment>();
            appointments.Add(new Appointment() { Id = 1, Date = new DateTime(2018, 3, 1, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 2, Date = new DateTime(2018, 3, 2, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 3, Date = new DateTime(2018, 3, 2, 10, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });

            mockRepository.Setup(x => x.GetDoctorAppointments(1)).Returns(appointments);
            mockPatientService.Setup(x => x.GetPatient(1)).Returns(new Patient() { Id = 1 });
            mockDoctorService.Setup(x => x.GetDoctor(1)).Returns(new Doctor() { Id = 1 });

            var service = new AppointmentService(mockRepository.Object, mockPatientService.Object, mockDoctorService.Object);
            service.UpdateAppointment(3, new Appointment() { Id = 3, Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 20, 0), Doctor = new Doctor() { Id = 1 } });
        }

        [TestMethod]
        public void GetDoctorAvailableAppointments()
        {
            var appointments = new List<Appointment>();
            appointments.Add(new Appointment() { Id = 1, Date = new DateTime(2018, 3, 1, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 2, Date = new DateTime(2018, 3, 2, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });
            appointments.Add(new Appointment() { Id = 3, Date = new DateTime(2018, 3, 2, 10, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned } });

            mockRepository.Setup(x => x.GetDoctorAppointments(1)).Returns(appointments);

            var service = new AppointmentService(mockRepository.Object, mockPatientService.Object, mockDoctorService.Object);
            var result = service.GetDoctorAvailableAppointments(1);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void GetDoctorAsignedAppointments()
        {
            var appointments = new List<Appointment>();
            appointments.Add(new Appointment() { Id = 1, Date = new DateTime(2018, 3, 1, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned }, Patient = new Patient() { Id= 1 } });
            appointments.Add(new Appointment() { Id = 2, Date = new DateTime(2018, 3, 2, 8, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Assigned }, Patient = new Patient() { Id = 2 } } );
            appointments.Add(new Appointment() { Id = 3, Date = new DateTime(2018, 3, 2, 10, 20, 0), Doctor = new Doctor() { Id = 1 }, State = new State() { Id = (int)StateEnum.Cancelled }, Patient = new Patient() { Id = 3 } });

            mockRepository.Setup(x => x.GetDoctorAppointments(1)).Returns(appointments);
            mockPatientService.Setup(x => x.GetPatient(1)).Returns(new Patient() { Id = 1 });

            var service = new AppointmentService(mockRepository.Object, mockPatientService.Object, mockDoctorService.Object);
            var result = service.GetDoctorAsignedAppointments(1);
            Assert.AreEqual(2, result.Count);
        }
    }
}
