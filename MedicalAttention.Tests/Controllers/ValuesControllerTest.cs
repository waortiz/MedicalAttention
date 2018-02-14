using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedicalAttention;
using MedicalAttention.Controllers;

namespace MedicalAttention.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Disponer
            AppointmentController controller = new AppointmentController();

            // Actuar
            IEnumerable<string> result = controller.Get();

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Disponer
            AppointmentController controller = new AppointmentController();

            // Actuar
            string result = controller.Get(5);

            // Declarar
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Disponer
            AppointmentController controller = new AppointmentController();

            // Actuar
            controller.Post("value");

            // Declarar
        }

        [TestMethod]
        public void Put()
        {
            // Disponer
            AppointmentController controller = new AppointmentController();

            // Actuar
            controller.Put(5, "value");

            // Declarar
        }

        [TestMethod]
        public void Delete()
        {
            // Disponer
            AppointmentController controller = new AppointmentController();

            // Actuar
            controller.Delete(5);

            // Declarar
        }
    }
}
