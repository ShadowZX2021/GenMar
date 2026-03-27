using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class D_Rutas
    {
        public List<E_Rutas> ListadoRutas(bool? atiempo = null)
        {
            List<E_Rutas> lista = new List<E_Rutas>();

            using(SqlConnection conn = Conexion.ObtenerConexion())
            {

                SqlCommand cmd = new SqlCommand("Sp_Listar_Rutas", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (atiempo.HasValue)
                    cmd.Parameters.AddWithValue("@ATiempo", atiempo.Value);
                else
                    cmd.Parameters.AddWithValue("@ATiempo", DBNull.Value);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    lista.Add(new E_Rutas
                    {
                        IdRuta = Convert.ToInt32(dr["IdRuta"]),
                        IdChofer = Convert.ToInt32(dr["IdChofer"]),
                        IdCamion = Convert.ToInt32(dr["IdCamion"]),
                        NombreChofer = dr["NombreChofer"].ToString(),
                        Licencia = dr["Licencia"].ToString(),
                        TelefonoChofer = dr["TelefonoChofer"].ToString(),
                        FotoChofer = dr["FotoChofer"].ToString(),
                        Matricula = dr["Matricula"].ToString(),
                        FotoCamion = dr["FotoCamion"].ToString(),
                        Origen = dr["Origen"].ToString(),
                        Destino = dr["Destino"].ToString(),
                        FechaSalida = Convert.ToDateTime(dr["FechaSalida"]),
                        FechaLlegada = Convert.ToDateTime(dr["FechaLlegada"]),
                        ATiempo = Convert.ToBoolean(dr["ATiempo"]),
                        Distancia = Convert.ToDouble(dr["Distancia"]),
                        FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                    });
                }
            }
            return lista;
        }

        public bool InsertarRuta(E_Rutas ruta)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("Sp_Insert_Ruta", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdChofer", ruta.IdChofer);
                cmd.Parameters.AddWithValue("@IdCamion", ruta.IdCamion);
                cmd.Parameters.AddWithValue("@Origen", ruta.Origen);
                cmd.Parameters.AddWithValue("@Destino", ruta.Destino);
                cmd.Parameters.AddWithValue("@FechaSalida", ruta.FechaSalida);
                cmd.Parameters.AddWithValue("@FechaLlegada", ruta.FechaLlegada);
                cmd.Parameters.AddWithValue("@ATiempo", ruta.ATiempo);
                cmd.Parameters.AddWithValue("@Distancia", ruta.Distancia);
                cmd.Parameters.AddWithValue("@FechaRegistro", ruta.FechaRegistro);

                return cmd.ExecuteNonQuery() > 0; 
            }
        }

        public bool ActualizarRuta(E_Rutas ruta)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("Sp_Update_Ruta",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdRuta", ruta.IdRuta);
                cmd.Parameters.AddWithValue("@IdChofer", ruta.IdChofer);
                cmd.Parameters.AddWithValue("@IdCamion", ruta.IdCamion);
                cmd.Parameters.AddWithValue("@Origen", ruta.Origen);
                cmd.Parameters.AddWithValue("@Destino", ruta.Destino);
                cmd.Parameters.AddWithValue("@FechaSalida", ruta.FechaSalida);
                cmd.Parameters.AddWithValue("@FechaLlegada", ruta.FechaLlegada);
                cmd.Parameters.AddWithValue("@ATiempo", ruta.ATiempo);
                cmd.Parameters.AddWithValue("@Distancia", ruta.Distancia);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarRuta(int idRuta,int idChofer,int idCamiones)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("Sp_Delete_Ruta", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdRuta", idRuta);
                cmd.Parameters.AddWithValue("@IdChofer", idChofer);
                cmd.Parameters.AddWithValue("@IdCamion", idCamiones);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public E_Rutas ObtenerRutaPorID(int idRuta)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SP_ObtenerRutaPorId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdRuta", idRuta);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return new E_Rutas
                    {
                        IdRuta = Convert.ToInt32(dr["IdRuta"]),
                        IdChofer = Convert.ToInt32(dr["IdChofer"]),
                        IdCamion = Convert.ToInt32(dr["IdCamion"]),
                        Origen = dr["Origen"].ToString(),
                        Destino = dr["Destino"].ToString(),
                        FechaSalida = Convert.ToDateTime(dr["FechaSalida"]),
                        FechaLlegada = Convert.ToDateTime(dr["FechaLlegada"]),
                        ATiempo = Convert.ToBoolean(dr["ATiempo"]),
                        Distancia = Convert.ToDouble(dr["Distancia"]),
                        FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                        NombreChofer = dr["NombreChofer"].ToString(),
                        Licencia = dr["Licencia"].ToString(),
                        TelefonoChofer = dr["TelefonoChofer"].ToString(),
                        FotoChofer = dr["FotoChofer"].ToString(),
                        Matricula = dr["Matricula"].ToString(),
                        FotoCamion = dr["FotoCamion"].ToString()
                    };
                }

                return null;
            }
        }

    }
}
