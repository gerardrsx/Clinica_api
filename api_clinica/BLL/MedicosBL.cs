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
    public class MedicosBL
    {
        /// <summary>
        /// Metodo de capa de negocios para consultar Medicos
        /// </summary>
        /// <returns>Lista de Medicos</returns>
        public List<Medicos> Consultar()
        {
            try
            {
                var _DAL = new MedicosDAL();

                return _DAL.Consultar();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Metodo de capa de negocios para consultar Medicos por id
        /// </summary>
        /// <param name="id">Id del medico</param>
        /// <returns>Objeto con la informacion del medico</returns>
        public Medicos ConsultarPorId(int id)
        {
            try
            {
                var _DAL = new MedicosDAL();

                return _DAL.ConsultarPorId(id);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Metodo para mantenimiento de Medicos
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int ameMedicos(Medicos obj)
        {
            try
            {
                var _DAL = new MedicosDAL();

                return _DAL.ameMedicos(obj);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
    }
}