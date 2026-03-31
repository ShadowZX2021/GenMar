using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using VO;

namespace DAL
{
    public class D_Categorias
    {
        public List<V_Categorias> ListarCategorias()
        {
            List<V_Categorias>lista = new List<V_Categorias>();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarCategoria",conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read()) {
                    lista.Add(new V_Categorias { 
                        IdCategoria = Convert.ToInt32(dr["IdCategorias"]),
                        Nombre = dr["Nombre"].ToString(),
                        Descripcion = dr["Descripcion"].ToString()
                    });
                }
            }
            return lista;
        }

        public bool InsertarCategoria(V_Categorias categoria)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarCategoria", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

                return cmd.ExecuteNonQuery()>0;
            }
        }

        public bool ActualizarCategorias(V_Categorias categorias)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarCategoria", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdCategorias", categorias.IdCategoria);
                cmd.Parameters.AddWithValue("@Nombre", categorias.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", categorias.Descripcion);

                return cmd.ExecuteNonQuery()>0;
            }
        }

        public bool EliminarCategoria(int idCategoria)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarCategoria", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdCategorias", idCategoria);

                return cmd.ExecuteNonQuery()>0;
            }
        }

        public V_Categorias ObtenerCategoriaPorId(int idCategoria)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerCategoriasPorId", conn);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCategorias", idCategoria);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) {
                    return new V_Categorias{

                        IdCategoria = Convert.ToInt32(dr["IdCategorias"]),
                        Nombre = dr["Nombre"].ToString(),
                        Descripcion = dr["Descripcion"].ToString()
                    };
                }
            }
            return null;
        }
    }
}
