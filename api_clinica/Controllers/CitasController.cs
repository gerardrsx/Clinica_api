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
    public class CitasController : ApiController
    {
        // GET: api/Citas
        public List<Citas> Get()
        {
            var _BL = new CitasBL();

            var ListaCitas = _BL.Consultar();

            return ListaCitas;
        }

        // GET: api/Citas/5
        public Citas Get(int id)
        {
            var _BL = new CitasBL();

            var Cita = _BL.ConsultarPorId(id);

            return Cita;
        }

        // POST: api/Citas
        public int Post([FromBody] Citas cita)
        {
            var _BL = new CitasBL();

            var Resultado = _BL.ameCitas(cita);

            return Resultado;
        }
    }
}
