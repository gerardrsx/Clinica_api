using api_clinica.DAL;
using api_clinica.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace api_clinica.BLL
{
    public class PacientesBL
    {

        /// <summary>
        /// Metodo de capa de negocios para consultar Pacientes
        /// </summary>
        /// <returns>Lista de Pacientes</returns>
        public List<Pacientes> Consultar()
        {
            try
            {
                var _DAL = new PacientesDAL();

                return _DAL.Consultar();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Metodo de capa de negocios para consultar pacientes por id
        /// </summary>
        /// <param name="id">Id del paciente</param>
        /// <returns>Objeto con la informacion del paciente</returns>
        public Pacientes ConsultarPorId(int id)
        {
            try
            {
                var _DAL = new PacientesDAL();

                return _DAL.ConsultarPorId(id);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Metodo para mantenimiento de Pacientes
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int amePacientes(Pacientes obj)
        {
            try
            {
                var _DAL = new PacientesDAL();

                return _DAL.amePacientes(obj);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }


    }
}