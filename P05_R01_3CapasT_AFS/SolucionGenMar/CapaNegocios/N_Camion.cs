using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class N_Camion
    {
        private D_Camion objDatos = new D_Camion();

        public List<E_Camion> ListarCamiones(bool ? disponibilidad = null)
        {
            try
            {
                return objDatos.ListarCamiones(disponibilidad);
            }
            catch (Exception ex)
            {

                throw new Exception("Error en capa de negocio " + ex.Message);
            }
        }

        public string InsertarCamion(E_Camion camion)
        {
            try
            {
                //Vallidaciones de negocio
                if (string.IsNullOrEmpty(camion.Matricula))
                    return "La matricula es obligatoria";

                if (string.IsNullOrEmpty(camion.TipoCamion))
                    return "El tipo camion es obligatorio";

                if (camion.Modelo < 1900 || camion.Modelo > DateTime.Now.Year + 1)
                    return "El modelo debe estar entre 1900 y" + (DateTime.Now.Year + 1);

                if (string.IsNullOrEmpty(camion.Marca))
                    return "Lamarca es obligatoria";

                if (camion.Capacidad < 0)
                    return "La capacidad debe ser mayor a 0";

                if (camion.Kilometraje < 0)
                    return "El kilometraje no puede se negativo";

                //Verifica si existe matricula
                if (objDatos.ExisteMatricula(camion.Matricula))
                    return "Ya existe un camión con esa matricula";

                //Insetar
                if (objDatos.InsertarCamion(camion))
                    return "OK";
                else
                    return "No se puede insertar el camion";
            }
            catch(Exception ex)
            {
                return"Error: "+ ex.Message;
            }
        }

        public string ActualizarCamion(E_Camion camion)
        {
            try
            {
                //Validaciones similares al insertar
                if (string.IsNullOrEmpty(camion.Matricula))
                    return "Lamatricula es obligatoria";

                if (camion.Modelo < 1900 || camion.Modelo > DateTime.Now.Year + 1)
                    return "El modelo no es valido";

                if (camion.Capacidad < 0)
                    return "La capacidad debe ser mayor a 0";

                if (objDatos.ActualizarCamion(camion))
                    return "OK";
                else
                    return "No se pudo actualizar el camion";
            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }
        }

        public string EliminarCamion(int idCamion)
        {
            try
            {
                if (objDatos.EliminarCamion(idCamion))
                    return "OK";
                else
                    return "No se pudo eliminar el camion";
            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }
        }

        public E_Camion ObtenerCamionPorId(int idCamion)
        {
            try
            {
                return objDatos.ObtenerCamionPorID(idCamion);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
