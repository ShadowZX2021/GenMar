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
    public class D_Gastos
    {
        public List<V_Gastos> ListarGastos()
        {
            List<V_Gastos> lista = new List<V_Gastos>();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarGastos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    lista.Add(new V_Gastos
                    {
                        IdGastos = Convert.ToInt32(dr["IdGastos"]),
                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        IdCategoria = Convert.ToInt32(dr["IdCategorias"]),
                        Monto = Convert.ToDecimal(dr["Monto"]),
                        Descripcion = dr["Descripcion"].ToString(),
                        Fecha = Convert.ToDateTime(dr["Fecha"]),
                        NombrePersona = dr["NombrePersona"].ToString(),
                        Usuario = dr["Usuario"].ToString(),
                        Categoria = dr["Categoria"].ToString()
                    });

                }
            }
            return lista;
        }

        public bool InsertarGastos(V_Gastos gastos)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarGastos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", gastos.IdUsuario);
                cmd.Parameters.AddWithValue("@IdCategorias", gastos.IdCategoria);
                cmd.Parameters.AddWithValue("@Monto", gastos.Monto);
                cmd.Parameters.AddWithValue("@Descripcion", gastos.Descripcion);

                return cmd.ExecuteNonQuery() > 0;

            }
        }

        public bool EliminarGastos(int idGastos)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarGastos", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdGastos", idGastos);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
