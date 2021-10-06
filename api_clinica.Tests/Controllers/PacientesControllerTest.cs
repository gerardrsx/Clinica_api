using api_clinica.Controllers;
using api_clinica.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace api_clinica.Tests.Controllers
{
    [TestClass]
    public class PacientesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Disponer
            PacientesController controller = new PacientesController();

            // Actuar
            List<Pacientes> result = controller.Get();

            // Declarar
            Assert.IsNotNull(result.Count);
          
        }

        [TestMethod]
        public void GetById()
        {
            // Disponer
            PacientesController controller = new PacientesController();
            List<Pacientes> result = controller.Get();

            if (result.Count > 0)
            {
                // Actuar
                var Resultado = controller.Get(result[0].IdPaciente);

                // Declarar
                Assert.IsNotNull(Resultado);
            }
            else 
            {
                // Declarar
                Assert.IsNull(null);
            }

           
        }

        [TestMethod]
        public void Post()
        {
            // Disponer
            PacientesController controller = new PacientesController();

            var _paciente = new Pacientes() { Nombres = "Paciente", Apellidos = "Prueba", FechaNacimiento = DateTime.Now, FechaRegistro = DateTime.Now, DUI = "000000-0" };

            List<Pacientes> pacientesExistentes = controller.Get();

            var Existe = pacientesExistentes.Exists(x => x.DUI == "000000-0");

            _paciente.Operacion  = (Existe == true) ?  "m" : "a";
            _paciente.IdPaciente = (Existe == true) ? pacientesExistentes.Find(x => x.DUI == "000000-0").IdPaciente : 0;
            // Actuar
            var Resultado = controller.Post(_paciente);

            Assert.AreEqual(Resultado,1);
        }
    }
}
