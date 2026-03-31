using DAL;
using System;
using System.Collections.Generic;

using VO;

namespace BLL
{
    public class B_DatosPersonales
    {
        private D_DatosPersonales datos = new D_DatosPersonales();
        public List<V_DatosPersonales> ListarDatosPersonales()
        {
            try
            {
                return datos.ListatDatosPersonales();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en capa de negocio "+ex.Message);
            }
        }

        public string InsertarDatosPersonales(V_DatosPersonales datosPersonales)
        {
            try
            {
                if (string.IsNullOrEmpty(datosPersonales.Nombre))
                    return "El nombre es obliatosrio";
                if (string.IsNullOrEmpty(datosPersonales.ApPaterno))
                    return "El apellido paterno es obliatosrio"; 
                if (string.IsNullOrEmpty(datosPersonales.ApMaterno))
                    return "El apellido materno es obliatosrio"; 
                if (string.IsNullOrEmpty(datosPersonales.Telefono))
                    return "El telefono es obliatosrio";
                if (string.IsNullOrEmpty(datosPersonales.Direccion))
                    return "La direccion es obliatosria";

                if (datos.InsertarDatosPersonales(datosPersonales))
                    return "OK";
                else
                    return "No se pudieron insertar los datos personales";
            }
            catch (Exception ex)
            {

                return"Error: "+ ex.Message;
            }

        }

        public string ActualizarDatosPersonales(V_DatosPersonales datosPersonales)
        {
            try
            {
                if (string.IsNullOrEmpty(datosPersonales.Nombre))
                    return "El nombre es obliatosrio";
                if (string.IsNullOrEmpty(datosPersonales.ApPaterno))
                    return "El apellido paterno es obliatosrio";
                if (string.IsNullOrEmpty(datosPersonales.ApMaterno))
                    return "El apellido materno es obliatosrio";
                if (string.IsNullOrEmpty(datosPersonales.Telefono))
                    return "El telefono es obliatosrio";
                if (string.IsNullOrEmpty(datosPersonales.Direccion))
                    return "La direccion es obliatosria";

                if (datos.ActualizarDatosPersonales(datosPersonales))
                    return "OK";
                else
                    return "No se pudieron actualizar los datos personales";
            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }
        }

        public string EliminarDatosPersonales(int idDatos)
        {
            try
            {
                if (datos.EliminarDatosPersonales(idDatos))
                    return "OK";
                else
                    return "No se pudo eliminar los datos personales";
            }
            catch (Exception ex)
            {
                return "Error: "+ex.Message;
            }
        }

        public V_DatosPersonales ObtenerDatosPersonalesId(int idDatos)
        {
            try
            {
                return datos.ObtenerDatosPersonalesId(idDatos);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
