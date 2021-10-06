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
    public class MedicosDAL
    {
        /// <summary>
        /// Metodo de consulta de Medicos
        /// </summary>
        /// <returns>Lista de Medicos</returns>
        public List<Medicos> Consultar()
        {

            try
            {

                List<Medicos> listaMedicos = new List<Medicos>();
                string CS = ConfigurationManager.ConnectionStrings["Clinica"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("ConsultarMedicos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var medico = new Medicos();

                        medico.IdMedico = Convert.ToInt32(rdr["IdMedico"]);
                        medico.Nombres = rdr["Nombres"].ToString();
                        medico.Apellidos = rdr["Apellidos"].ToString();
                        medico.Especialidad = rdr["Especialidad"].ToString();
                        listaMedicos.Add(medico);
                    }
                    con.Close();
                }
                return listaMedicos;
            }
            catch (Exception ex)
            {

                return null;
            }


        }

        /// <summary>
        /// Metodo de consulta de medico por id
        /// </summary>
        /// <param name="IdMedico">Id del Medico</param>
        /// <returns>Retorna un medico en especifico</returns>
        public Medicos ConsultarPorId(int IdMedico)
        {
            try
            {
                var medico = new Medicos();

                string CS = ConfigurationManager.ConnectionStrings["Clinica"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("ConsultarMedicos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdMedico", IdMedico);
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        medico.IdMedico = Convert.ToInt32(rdr["IdMedico"]);
                        medico.Nombres = rdr["Nombres"].ToString();
                        medico.Apellidos = rdr["Apellidos"].ToString();
                        medico.Especialidad = rdr["Especialidad"].ToString();
                    }
                    con.Close();
                    return medico;
                }
            }
            catch (Exception ex)
            {

                return null;
            }



        }

        /// <summary>
        /// Metodo para mantenimiento de medicos, en base al parametro operacion realiza la operacion solicitada.
        /// </summary>
        /// <param name="medico">Objeto conla informacion del medico</param>
        /// <returns>1: si fue exitoso, 0 si ocurrio algun error</returns>
        public int ameMedicos(Medicos medico)
        {

            try
            {
                string CS = ConfigurationManager.ConnectionStrings["Clinica"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("ameMedicos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Operacion", medico.Operacion);
                    cmd.Parameters.AddWithValue("@IdMedico", medico.IdMedico);
                    cmd.Parameters.AddWithValue("@Nombres", medico.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", medico.Apellidos);
                    cmd.Parameters.AddWithValue("@Especialidad", medico.Especialidad);
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