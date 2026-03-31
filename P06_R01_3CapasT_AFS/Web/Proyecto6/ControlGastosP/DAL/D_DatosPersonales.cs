using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class D_DatosPersonales
    {
        public List<V_DatosPersonales> ListatDatosPersonales()
        {
            List<V_DatosPersonales> lista = new List<V_DatosPersonales>();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarDatosPersonales", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    lista.Add(new V_DatosPersonales { 
                        IdDatos = Convert.ToInt32(dr["IdDatos"]),
                        Nombre = dr["Nombre"].ToString(),
                        ApPaterno = dr["ApPaterno"].ToString(),
                        ApMaterno = dr["ApMaterno"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Direccion = dr["Direccion"].ToString()
                    
                    });
                }
            }
            return lista;
        }

        public bool InsertarDatosPersonales(V_DatosPersonales datosPersonales)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarDatosPersonales", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", datosPersonales.Nombre);
                cmd.Parameters.AddWithValue("@ApPaterno", datosPersonales.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", datosPersonales.ApMaterno);
                cmd.Parameters.AddWithValue("@Telefono", datosPersonales.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", datosPersonales.Direccion);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ActualizarDatosPersonales(V_DatosPersonales datosPersonales)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarDatosPersonales", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdDatos", datosPersonales.IdDatos);
                cmd.Parameters.AddWithValue("@Nombre", datosPersonales.Nombre);
                cmd.Parameters.AddWithValue("@ApPaterno", datosPersonales.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", datosPersonales.ApMaterno);
                cmd.Parameters.AddWithValue("@Telefono", datosPersonales.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", datosPersonales.Direccion);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarDatosPersonales(int idDatos)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarDatosPersonales", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdDatos", idDatos);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public V_DatosPersonales ObtenerDatosPersonalesId(int idDatos)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerDatosPersonalesID", conn);
                cmd.CommandType =CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdDatos", idDatos);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return new V_DatosPersonales
                    {
                        IdDatos = Convert.ToInt32(dr["IdDatos"]),
                        Nombre = dr["Nombre"].ToString(),
                        ApPaterno = dr["ApPaterno"].ToString(),
                        ApMaterno = dr["ApMaterno"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Direccion = dr["Direccion"].ToString()
                    };
                }
                return null;

            }
        }
    }
}
