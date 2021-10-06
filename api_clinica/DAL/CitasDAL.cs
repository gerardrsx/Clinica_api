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
    public class CitasDAL
    {
        /// <summary>
        /// Metodo de consulta de Citas
        /// </summary>
        /// <returns>Lista de Citas</returns>
        public List<Citas> Consultar()
        {

            try
            {

                List<Citas> listaCitas = new List<Citas>();
                string CS = ConfigurationManager.ConnectionStrings["Clinica"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("ConsultarCitas", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var cita = new Citas();

                        cita.IdCita = Convert.ToInt32(rdr["IdCita"]);
                        cita.IdPaciente = Convert.ToInt32(rdr["IdPaciente"]);
                        cita.Paciente = rdr["Paciente"].ToString();
                        cita.IdMedico = Convert.ToInt32(rdr["IdMedico"]);
                        cita.Medico = rdr["Medico"].ToString();
                        cita.FechaCita = Convert.ToDateTime(rdr["FechaCita"]);

                        if (rdr["FechaDiagnostico"] == DBNull.Value)
                        {
                            cita.FechaDiagnostico = null;

                        }
                        else
                        {
                            cita.FechaDiagnostico = Convert.ToDateTime(rdr["FechaDiagnostico"]);

                        }
                        cita.Diagnostico = rdr["Diagnostico"].ToString();
                        listaCitas.Add(cita);
                    }
                    con.Close();
                }
                return listaCitas;
            }
            catch (Exception ex)
            {

                return null;
            }


        }

        /// <summary>
        /// Metodo de consulta de cita por id
        /// </summary>
        /// <param name="IdCita">Id de la Cita</param>
        /// <returns>Retorna una cita en especifico</returns>
        public Citas ConsultarPorId(int IdCita)
        {
            try
            {
                var cita = new Citas();

                string CS = ConfigurationManager.ConnectionStrings["Clinica"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("ConsultarCitas", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCita", IdCita);
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        cita.IdCita = Convert.ToInt32(rdr["IdCita"]);
                        cita.IdPaciente = Convert.ToInt32(rdr["IdPaciente"]);
                        cita.Paciente = rdr["Paciente"].ToString();
                        cita.IdMedico = Convert.ToInt32(rdr["IdMedico"]);
                        cita.Medico = rdr["Medico"].ToString();
                        cita.FechaCita = Convert.ToDateTime(rdr["FechaCita"]);
                        if (rdr["FechaDiagnostico"] == DBNull.Value)
                        {
                            cita.FechaDiagnostico = null;

                        }
                        else
                        {
                            cita.FechaDiagnostico = Convert.ToDateTime(rdr["FechaDiagnostico"]);

                        }
                        cita.Diagnostico = rdr["Diagnostico"].ToString();
                    }
                    con.Close();
                    return cita;
                }
            }
            catch (Exception ex)
            {

                return null;
            }



        }


        /// <summary>
        /// Metodo para mantenimiento de citas, en base al parametro operacion realiza la operacion solicitada.
        /// </summary>
        /// <param name="cita">Objeto conla informacion de la cita</param>
        /// <returns>1: si fue exitoso, 0 si ocurrio algun error</returns>
        public int ameCitas(Citas cita)
        {

            try
            {
                string CS = ConfigurationManager.ConnectionStrings["Clinica"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("ameCitas", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Operacion", cita.Operacion);
                    cmd.Parameters.AddWithValue("@IdCita", cita.IdCita);
                    cmd.Parameters.AddWithValue("@IdPaciente", cita.IdPaciente);
                    cmd.Parameters.AddWithValue("@IdMedico", cita.IdMedico);
                    cmd.Parameters.AddWithValue("@FechaCita", cita.FechaCita);
                    if (!String.IsNullOrEmpty(cita.Diagnostico))
                    {
                        cmd.Parameters.AddWithValue("@FechaDiagnostico", cita.FechaDiagnostico);
                        cmd.Parameters.AddWithValue("@Diagnostico", cita.Diagnostico);
                    }
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