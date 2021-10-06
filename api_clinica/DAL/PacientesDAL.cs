using api_clinica.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace api_clinica.DAL
{
    public class PacientesDAL
    {
        /// <summary>
        /// Metodo de consulta de Pacientes
        /// </summary>
        /// <returns>Lista de Pacientes</returns>
        public List<Pacientes> Consultar()
        {
            try
            {
                List<Pacientes> listaPacientes = new List<Pacientes>();
                string CS = ConfigurationManager.ConnectionStrings["Clinica"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("ConsultarPacientes", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var paciente = new Pacientes();

                        paciente.IdPaciente = Convert.ToInt32(rdr["IdPaciente"]);
                        paciente.Nombres = rdr["Nombres"].ToString();
                        paciente.Apellidos = rdr["Apellidos"].ToString();
                        paciente.DUI = rdr["DUI"].ToString();
                        paciente.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                        paciente.FechaRegistro = Convert.ToDateTime(rdr["FechaRegistro"]);
                        listaPacientes.Add(paciente);
                    }
                    con.Close();
                }
                return listaPacientes;
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        /// <summary>
        /// Metodo de consulta de paciente por id
        /// </summary>
        /// <param name="IdPaciente">Id del paciente</param>
        /// <returns>Retorna un paciente en especifico</returns>
        public Pacientes ConsultarPorId(int IdPaciente)
        {

            try
            {
                var paciente = new Pacientes();

                string CS = ConfigurationManager.ConnectionStrings["Clinica"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("ConsultarPacientes", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPaciente", IdPaciente);
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        paciente.IdPaciente = Convert.ToInt32(rdr["IdPaciente"]);
                        paciente.Nombres = rdr["Nombres"].ToString();
                        paciente.Apellidos = rdr["Apellidos"].ToString();
                        paciente.DUI = rdr["DUI"].ToString();
                        paciente.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                        paciente.FechaRegistro = Convert.ToDateTime(rdr["FechaRegistro"]);
                    }
                    con.Close();
                    return paciente;
                }
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        /// <summary>
        /// Metodo para mantenimiento de pacientes, en base al parametro operacion realiza la operacion solicitada.
        /// </summary>
        /// <param name="paciente">Objeto conla informacion del paciente</param>
        /// <returns>1: si fue exitoso, 0 si ocurrio algun error</returns>
        public int amePacientes(Pacientes paciente)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["Clinica"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("amePacientes", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Operacion", paciente.Operacion);
                    cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    cmd.Parameters.AddWithValue("@Nombres", paciente.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", paciente.Apellidos);
                    cmd.Parameters.AddWithValue("@DUI", paciente.DUI);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", paciente.FechaNacimiento);
                    cmd.Connection = con;
                    con.Open();
                    var Resultado = cmd.ExecuteNonQuery();
                    con.Close();

                    return Resultado;
                }
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
    }
}