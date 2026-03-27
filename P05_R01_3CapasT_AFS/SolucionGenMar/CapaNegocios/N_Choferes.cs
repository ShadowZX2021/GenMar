using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class N_Choferes
    {
        private D_Chofer objDatos = new D_Chofer();

        public List<E_Chofer> ListarChoferes(bool ? disponibilidad = null)
        {
            try
            {
                return objDatos.ListarChoferes(disponibilidad);
            }
            catch (Exception ex)
            {

                throw new Exception("Error en capa de negocios: " + ex.Message);
            }
        }

        public string InsertarChofer(E_Chofer chofer)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrEmpty(chofer.Nombre))
                    return "El nombre es obligatorio";

                if (string.IsNullOrEmpty(chofer.ApPaterno))
                    return "El apellido paterno es obligatorio";

                if (string.IsNullOrEmpty(chofer.ApMaterno))
                    return "El apellido materno es obligatorio";

                if (string.IsNullOrEmpty(chofer.Telefono))
                    return "El teléfono es obligatorio";

                if (chofer.Telefono.Length != 10)
                    return "El teléfono debe tener 10 digitos";

                if (string.IsNullOrEmpty(chofer.Licencia))
                    return "La licencia es obligatoria";

                //Valida edad minima(18 años)
                int edad = DateTime.Now.Year - chofer.FechaNacimiento.Year;
                if (chofer.FechaNacimiento > DateTime.Now.AddYears(-edad)) edad--;
                if (edad < 18)
                    return "El chofer debe se nayor de 18 años";

                // Valida si existe la licencia
                if (objDatos.ExisteLicencia(chofer.Licencia))
                    return "Ya existe una chofer con esa licencia";

                if (objDatos.InsertarChofer(chofer))
                    return "OK";
                else
                    return "No se pudo insertar el chofer";

            }
            catch (Exception ex)
            {
                
                return "Error" + ex.Message;
            }
        }

        public string ActializarChofer(E_Chofer chofer)
        {
            try
            {
                if (string.IsNullOrEmpty(chofer.Nombre))
                    return "El nombre es obligatorio";

                if (chofer.Telefono.Length != 10)
                    return "El telefono debe de tener 10 digitos";

                if (objDatos.ActualizarChofer(chofer))
                    return "OK";
                else
                    return "No se puede actualizar el chofer";
            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }
        }

        public string EliminarChofer(int idChofer)
        {
            try
            {
                if (objDatos.EliminarChofer(idChofer))
                    return "OK";
                else
                    return "No se puedo eliminar el chofer";
            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }
        }
         
        public E_Chofer ObtenerChoferPorId(int idChofer)
        {
            try
            {
                return objDatos.ObtenerChoferPorID(idChofer);

            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
