using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class N_Ruta
    {
        private D_Rutas objDatos = new D_Rutas();

        public List<E_Rutas>ListarRutas()
        {
            try
            {
                return objDatos.ListadoRutas();
            }
            catch (Exception ex)
            {

                throw new Exception("Error en capa de negocio: " + ex.Message);
            }
        }

        public string InsertarRuta(E_Rutas ruta)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrEmpty(ruta.Origen))
                    return "El origen es obligatorio";

                if (string.IsNullOrEmpty(ruta.Destino))
                    return "El destino es obligatorio";

                if (ruta.FechaSalida >= ruta.FechaLlegada)
                    return "La fecha de llegada debe ser posterior a la fecha de salida";

                if (ruta.Distancia <= 0)
                    return "La distancia debe ser mayor a 0";

                if (ruta.IdChofer <= 0)
                    return "Debe seleccionar un chofer";

                if (objDatos.InsertarRuta(ruta))
                    return "OK";
                else
                    return "No se pudo insertar la ruta";
            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }
        }

        public string ActualizarRuta(E_Rutas ruta)
        {
            try
            {
                if (ruta.FechaSalida >= ruta.FechaLlegada)
                    return "La fecha de llegada debe ser posterior a la fecha de salida";

                if (ruta.Distancia <= 0)
                    return "La distancia debe se mayor a 0";

                if (objDatos.ActualizarRuta(ruta))
                    return "OK";
                else
                    return "No se pudo actualizar la ruta";
            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }
        }

        public string EliminarRuta(int idRuta,int idChofer, int idCamion)
        {
            try
            {
                if (objDatos.EliminarRuta(idRuta,idChofer,idCamion))
                    return "OK";
                else
                    return "No se pudo eliminar la ruta";
            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }
        }

        public E_Rutas ObtenerRutaPorId(int idRuta)
        {
            try
            {
                return objDatos.ObtenerRutaPorID(idRuta);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
