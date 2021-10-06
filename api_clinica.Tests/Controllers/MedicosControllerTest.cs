using api_clinica.Controllers;
using api_clinica.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace api_clinica.Tests.Controllers
{
    [TestClass]
    public class MedicosControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Disponer
            MedicosController controller = new MedicosController();

            // Actuar
            List<Medicos> result = controller.Get();

            // Declarar
            Assert.IsNotNull(result.Count);

        }

        [TestMethod]
        public void GetById()
        {
            // Disponer
            MedicosController controller = new MedicosController();
            List<Medicos> result = controller.Get();

            if (result.Count > 0)
            {
                // Actuar
                var Resultado = controller.Get(result[0].IdMedico);

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
            MedicosController controller = new MedicosController();

            var _medico = new Medicos() { Nombres = "Medico", Apellidos = "Prueba",Especialidad = "Prueba Unitaria" };

            List<Medicos> medicosExistentes = controller.Get();

            var Existe = medicosExistentes.Exists(x => x.Especialidad == "Prueba Unitaria");

            _medico.Operacion = (Existe == true) ? "m" : "a";
            _medico.IdMedico = (Existe == true) ? medicosExistentes.Find(x => x.Especialidad == "Prueba Unitaria").IdMedico : 0;
            // Actuar
            var Resultado = controller.Post(_medico);

            Assert.AreEqual(Resultado, 1);
        }
    }
}
