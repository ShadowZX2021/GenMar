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
    public class D_Usuarios
    {
        public List<V_Usuarios> ListarUsuarios()
        {
            List<V_Usuarios> lista = new List<V_Usuarios>();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarUsuarios", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new V_Usuarios
                    {
                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        IdDatos = Convert.ToInt32(dr["Iddatos"]),
                        Nombre = dr["Nombre"].ToString(),
                        Email = dr["Email"].ToString(),
                        Password = dr["Password"].ToString()
                    });
                }
            }
            return lista;
        }

        public bool InsertarUsuario(V_Usuarios usuario)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarUsuario", conn);
                cmd.CommandType= CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdDatos", usuario.IdDatos);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Password", usuario.Password);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        
        public bool ActualizarUsuario(V_Usuarios usuario)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarUsario", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@IdDatos", usuario.IdDatos);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Password", usuario.Password);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarUsuario(int idUsuario)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("IdUsuario", idUsuario);

                return cmd.ExecuteNonQuery() > 0;

            }
        }

        public bool LoginUsuario(V_Usuarios usuario)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_LoginUsuario", conn);
                cmd.CommandType= CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Password", usuario.Password);

                SqlDataReader dr = cmd.ExecuteReader();
                return dr.HasRows;
            }
        }

        public V_Usuarios ObtenerUsuarioID(int idUsuario)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarioId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                SqlDataReader dr =cmd.ExecuteReader();

                if (dr.Read()) {
                    return new V_Usuarios {

                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        IdDatos = Convert.ToInt32(dr["Iddatos"]),
                        Nombre = dr["Nombre"].ToString(),
                        Email = dr["Email"].ToString(),
                        Password = dr["Password"].ToString()
                    };
                }
                return null;
            }
        }

        public bool ExisteEmail(string email)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ExisteEmail", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);

                int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                return resultado > 0;
            }
        }

        public bool ExisteUsuario(int idDatos)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ExisteUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDatos", idDatos);

                int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                return resultado > 0;
            }
        }

        public List<V_Usuarios> DropListDatosPersonales()
        {
            List<V_Usuarios> lista = new List<V_Usuarios>();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_DropListDatosPersonales", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new V_Usuarios
                    {
                        IdDatos = Convert.ToInt32(dr["Iddatos"]),
                        Nombre = dr["Nombre"].ToString()
                    });
                }
            }
            return lista;
        }
    }
}
