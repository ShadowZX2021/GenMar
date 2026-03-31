using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Conexion
    {
        private static string CadenaConexion = "Server=USER;DataBase=ControlGastos;Trusted_Connection=True;";

        //Metodo para obtener conexion

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conn = new SqlConnection(CadenaConexion);
            try
            {
                conn.Open();
                return conn;
            }catch(Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos "+ex.Message);
            }
        }

        //Metodo para probar la conexion

        public static bool ProbarConexion()
        {
            try
            {
                using (SqlConnection conn = ObtenerConexion()) {
                    return conn.State == System.Data.ConnectionState.Open;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
