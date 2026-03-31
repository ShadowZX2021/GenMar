using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class B_Categorias
    {
        private D_Categorias datos = new D_Categorias();

        public List<V_Categorias> ListarCategorias()
        {
            try
            {
                return datos.ListarCategorias();
            }
            catch (Exception ex) 
            {
                throw new Exception("Error en capa de negocio " + ex.Message);
            }
        }

        public string InsetarCategoria(V_Categorias categorias)
        {
            try
            {
                if (string.IsNullOrEmpty(categorias.Nombre))
                    return "El nombre es obligatorio";
                if (string.IsNullOrEmpty(categorias.Descripcion))
                    return "La descripcion es obligatoria";

                if (datos.InsertarCategoria(categorias))
                    return "OK";
                else
                    return "No se puedo insertar la categoria";
            }
            catch (Exception ex)
            {
                return"Error: "+ ex.Message;
            }
        }

        public string ActualizarCategoria(V_Categorias categorias)
        {
            try
            {
                if (string.IsNullOrEmpty(categorias.Nombre))
                    return "El nombre es obligatorio";
                if (string.IsNullOrEmpty(categorias.Descripcion))
                    return "La descripcion es obligatoria";

                if (datos.ActualizarCategorias(categorias))
                    return "OK";
                else
                    return "No se puedo actualizar la categoria";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string EliminarCategoria(int idCategoria)
        {
            try
            {
                if (datos.EliminarCategoria(idCategoria))
                    return "OK";
                else
                    return "No se pudo eliminar la categoria";
            }
            catch (Exception ex) { 

                return"Error: "+ex.Message;

            }
        }

        public V_Categorias ObtenerCategoriaPorId(int idCategoria)
        {
            try
            {
                return datos.ObtenerCategoriaPorId(idCategoria);

            }catch(Exception ex)
            {
                throw new Exception("Error: "+ex.Message);
            }
        }
    }
}
