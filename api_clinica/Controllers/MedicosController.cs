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
    public class MedicosController : ApiController
    {
        // GET: api/Medicos
        public List<Medicos> Get()
        {
            var _BL = new MedicosBL();

            var ListaMedicos = _BL.Consultar();

            return ListaMedicos;
        }

        // GET: api/Medicos/5
        public Medicos Get(int id)
        {
            var _BL = new MedicosBL();

            var Medico = _BL.ConsultarPorId(id);

            return Medico;
        }

        // POST: api/Medicos
        public int Post([FromBody] Medicos medico)
        {
            var _BL = new MedicosBL();

            var Resultado = _BL.ameMedicos(medico);

            return Resultado;
        }
    }
}
