using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using VO;

namespace BLL
{
   
    public class B_Gastos
    {
        private D_Gastos datos = new D_Gastos();
        public List<V_Gastos> ListarGastos()
        {
            try
            {
                return datos.ListarGastos();
            }
            catch (Exception ex)
            {

                throw new Exception("Error en capa de negocio"+ ex.Message);
            }
        } 

        public string InsertarGastos(V_Gastos gastos)
        {
            try
            {
                if (gastos.IdUsuario <= 0)
                    return "Usuario invalido";
                if (gastos.IdCategoria <= 0)
                    return "Categoria invalida";
                if (gastos.Monto <= 0)
                    return "El monto debe ser mayor a 0";

                if (datos.InsertarGastos(gastos))
                    return "OK";
                else
                    return "No se pudo insertar el gasto";

            }
            catch (Exception ex)
            {

                return"Error: " + ex.Message;
            }
        }

        public string EliminarGastos(int idGastos)
        {
            try
            {
                if (datos.EliminarGastos(idGastos))
                    return "OK";
                else
                    return "No se elimino el gasto";
            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }
        }
    }
}
