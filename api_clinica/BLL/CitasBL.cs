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
    public class CitasBL
    {
        /// <summary>
        /// Metodo de capa de negocios para consultar citas
        /// </summary>
        /// <returns>Lista de Citas</returns>
        public List<Citas> Consultar()
        {
            try
            {
               var  _DAL = new CitasDAL();

                return _DAL.Consultar();
            }
            catch (Exception ex)
            {

                throw;
            }
        
        }
        
        /// <summary>
        /// Metodo de capa de negocios para consultar cita por id
        /// </summary>
        /// <param name="id">Id de la cita</param>
        /// <returns>Objeto con la informacion de la cita</returns>
        public Citas ConsultarPorId(int id)
        {
            try
            {
                var _DAL = new CitasDAL();

                return _DAL.ConsultarPorId(id);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Metodo para mantenimiento de citas
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int ameCitas(Citas obj) 
        {
            try
            {
                var _DAL = new CitasDAL();

                return _DAL.ameCitas(obj);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

    }
}