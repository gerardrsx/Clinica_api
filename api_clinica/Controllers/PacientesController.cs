using api_clinica.BLL;
using api_clinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_clinica.Controllers
{
    public class PacientesController : ApiController
    {
        // GET: api/Pacientes
        public List<Pacientes> Get()
        {
            var _BL = new PacientesBL();

            var ListaPacientes = _BL.Consultar();

            return ListaPacientes;
        }

        // GET: api/Pacientes/5
        public Pacientes Get(int id)
        {
            var _BL = new PacientesBL();

            var Paciente = _BL.ConsultarPorId(id);

            return Paciente;
        }

        // POST: api/Pacientes
        public int Post([FromBody]Pacientes paciente)
        {
            var _BL = new PacientesBL();

            var Resultado = _BL.amePacientes(paciente);

            return Resultado;
        }
    }
}
